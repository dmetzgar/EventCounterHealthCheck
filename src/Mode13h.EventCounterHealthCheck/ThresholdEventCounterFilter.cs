using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;

namespace Mode13h.EventCounterHealthCheck
{
    /// <summary>
    /// Compares event counter to a threshold to determine health.
    /// </summary>
    public class ThresholdEventCounterFilter : IEventCounterFilter
    {
        private readonly string _eventSourceName;
        private readonly string _counterName;
        private readonly double _unhealthyThreshold;
        private readonly double _degradedThreshold;
        private readonly MaxOrMin _maxOrMin;
        private double _currentValue;

        /// <summary>
        /// Filter for a counter on a given threshold
        /// </summary>
        /// <param name="eventSourceName">Event source name</param>
        /// <param name="counterName">Counter name</param>
        /// <param name="unhealthyThreshold">Threshold beyond which the counter is unhealthy</param>
        /// <param name="degradedThreshold">Threshold beyond which the counter's health is degraded</param>
        /// <param name="maxOrMin">Indicates if the counter threshold should be a maximum or minimum value</param>
        public ThresholdEventCounterFilter(string eventSourceName, string counterName, double unhealthyThreshold, double degradedThreshold, MaxOrMin maxOrMin)
        {
            _eventSourceName = eventSourceName;
            _counterName = counterName;
            _unhealthyThreshold = unhealthyThreshold;
            _degradedThreshold = degradedThreshold;
            _maxOrMin = maxOrMin;
        }

        public void OnEventWritten(EventCounterData eventCounterData)
        {
            if (string.Equals(eventCounterData.Name, _counterName, StringComparison.OrdinalIgnoreCase))
            {
                _currentValue = _maxOrMin == MaxOrMin.Max ? eventCounterData.Max : eventCounterData.Min;
            }
        }

        public bool ShouldRecordEventSource(string eventSourceName) =>
            string.Equals(eventSourceName, _eventSourceName, StringComparison.OrdinalIgnoreCase);

        public HealthStatus UpdateHealthStatus(Dictionary<string, object> data)
        {
            data.Add(_counterName, $"Current value: {_currentValue}, Degraded threshold: {_degradedThreshold}, Unhealthy threshold: {_unhealthyThreshold}");
            if (_maxOrMin == MaxOrMin.Max)
            {
                if (_currentValue >= _unhealthyThreshold)
                {
                    return HealthStatus.Unhealthy;
                }
                else if (_currentValue >= _degradedThreshold)
                {
                    return HealthStatus.Degraded;
                }
            }
            else
            {
                if (_currentValue <= _unhealthyThreshold)
                {
                    return HealthStatus.Unhealthy;
                }
                else if (_currentValue <= _degradedThreshold)
                {
                    return HealthStatus.Degraded;
                }
            }

            return HealthStatus.Healthy;
        }

        /// <summary>
        /// Indicates if the counter threshold should be a maximum or minimum value
        /// </summary>
        public enum MaxOrMin
        {
            Max,
            Min,
        }
    }
}
