using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mode13h.EventCounterHealthCheck
{
    internal class EventCounterHealthCheckHost : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private EventCounterHealthCheckListener _eventListener;

        public EventCounterHealthCheckHost(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventListener = _serviceProvider.GetService<EventCounterHealthCheckListener>();
            Task.Run(_eventListener.RunHealthCheckAsync);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _eventListener?.StopUpdates();
            return Task.CompletedTask;
        }
    }
}
