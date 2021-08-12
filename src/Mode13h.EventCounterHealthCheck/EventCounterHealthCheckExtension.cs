using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Mode13h.EventCounterHealthCheck
{
    /// <summary>
    /// Extensions for adding event counter health checks to your ASP.NET application.
    /// </summary>
    public static class EventCounterHealthCheckExtension
    {
        /// <summary>
        /// Use this in ConfigureServices and chain onto <see cref="HealthCheckServiceCollectionExtensions.AddHealthChecks(IServiceCollection)"/>
        /// </summary>
        /// <param name="builder">Health check builder</param>
        /// <returns>Health check builder</returns>
        public static IHealthChecksBuilder AddEventCounterHealthCheck(this IHealthChecksBuilder builder)
        {
            builder.Add(new HealthCheckRegistration(
                        "EventCounter health check",
                        sp => sp.GetService<EventCounterHealthCheckListener>(),
                        default,
                        default));
            return builder;
        }

        /// <summary>
        /// Use this in ConfigureServices and chain onto <see cref="IServiceCollection"/>
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service collection</returns>
        public static IServiceCollection InitEventCounterHealthCheck(this IServiceCollection services)
        {
            services.AddSingleton<EventCounterHealthCheckListener>();
            services.AddHostedService<EventCounterHealthCheckHost>();
            return services;
        }
    }
}
