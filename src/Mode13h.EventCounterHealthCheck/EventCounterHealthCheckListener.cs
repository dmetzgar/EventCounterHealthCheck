using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mode13h.EventCounterHealthCheck
{
    internal class EventCounterHealthCheckListener : EventListener, IHealthCheck
    {
        private readonly List<EventSource> _allEventSources = new List<EventSource>();
        private readonly IEnumerable<IEventCounterFilter> _filters;
        private readonly HealthCheckResult _defaultHealthCheckResult;
        private HealthCheckResult _healthCheckResult;
        private bool _isRunning = false;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ConcurrentDictionary<string, List<IEventCounterFilter>> _activeEventSources = new ConcurrentDictionary<string, List<IEventCounterFilter>>();
        private readonly List<WeakReference<EventSource>> _enabledEventSources = new List<WeakReference<EventSource>>();

        public EventCounterHealthCheckListener(IEnumerable<IEventCounterFilter> filters)
        {
            _defaultHealthCheckResult = new HealthCheckResult(HealthStatus.Unhealthy,
                "EventCounter health check not started");
            _healthCheckResult = _defaultHealthCheckResult;
            _filters = filters;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_healthCheckResult);
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            _allEventSources.Add(eventSource);
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (_isRunning 
                && _activeEventSources.TryGetValue(eventData.EventSource.Name, out var filterList)
                && TryGetCounter(eventData, out var payload))
            {
                foreach (var filter in filterList)
                {
                    filter.OnEventWritten(new EventCounterData(eventData.EventSource.Name, eventData.EventSource.Guid, payload));
                }
            }
        }

        internal async Task RunHealthCheckAsync()
        {
            CheckAllEventSources();
            if (_activeEventSources.Count > 0)
            {
                _isRunning = true;

                while (_isRunning)
                {
                    UpdateHealthCheckResult();
                    await Task.Delay(
                        TimeSpan.FromSeconds(1),
                        _cancellationTokenSource.Token);
                }
            }
        }

        internal void StopUpdates()
        {
            _isRunning = false;
            _cancellationTokenSource.Cancel();
            _healthCheckResult = _defaultHealthCheckResult;

            ReleaseEventSources();
        }

        private void UpdateHealthCheckResult()
        {
            HealthStatus worstHealthStatus = HealthStatus.Healthy;
            var data = new Dictionary<string, object>();
            foreach (var filter in _filters)
            {
                var filterStatus = filter.UpdateHealthStatus(data);
                if (filterStatus < worstHealthStatus)
                {
                    worstHealthStatus = filterStatus;
                }
            }

            _healthCheckResult = new HealthCheckResult(worstHealthStatus, data: data);
        }

        private void CheckAllEventSources()
        {
            foreach (EventSource eventSource in _allEventSources)
            {
                foreach (IEventCounterFilter filter in _filters)
                {
                    if (filter.ShouldRecordEventSource(eventSource.Name))
                    {
                        var filterList = _activeEventSources.GetOrAdd(eventSource.Name, _ => new List<IEventCounterFilter>());
                        filterList.Add(filter);
                        EnableEventSource(eventSource);
                    }
                }
            }

            _allEventSources.Clear();
        }

        private void EnableEventSource(EventSource eventSource)
        {
            if (!_enabledEventSources.Any(e => e.TryGetTarget(out var storedEventSource) && storedEventSource == eventSource))
            {
                var options = new Dictionary<string, string>
                {
                    // define time interval, otherwise event counters will not be enabled
                    { "EventCounterIntervalSec", "1" }
                };

                // enable for the None keyword
                EnableEvents(eventSource, EventLevel.Informational, EventKeywords.None, options);
                _enabledEventSources.Add(new WeakReference<EventSource>(eventSource));
            }
        }

        private void ReleaseEventSources()
        {
            foreach (WeakReference<EventSource> eventSourceRef in _enabledEventSources)
            {
                if (eventSourceRef.TryGetTarget(out EventSource eventSource))
                {
                    DisableEvents(eventSource);
                }
            }
        }

        private bool TryGetCounter(EventWrittenEventArgs eventData, out IDictionary<string, object> payload)
        {
            payload = null;

            if (eventData.EventName == "EventCounters")
            {
                payload = eventData.Payload.FirstOrDefault(
                    p => p is IDictionary<string, object> x && x.ContainsKey("Name"))
                    as IDictionary<string, object>;
            }

            return payload != null;
        }
    }
}
