using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;

namespace Mode13h.EventCounterHealthCheck
{
    /// <summary>
    /// Implement this interface to create a custom Event Counter filter for health checks.
    /// </summary>
    public interface IEventCounterFilter
    {
        /// <summary>
        /// Return true if you want to receive events from this event source.
        /// </summary>
        /// <param name="eventSourceName">Event source name</param>
        /// <returns>True to get events from this event source</returns>
        bool ShouldRecordEventSource(string eventSourceName);

        /// <summary>
        /// Called when an event from one of the event sources listened to emits an event.
        /// </summary>
        /// <param name="eventCounterData">Parsed event counter data</param>
        /// <remarks>
        /// This method should not perform long-running operations as it will block other filters from getting events. Also note 
        /// this only works with event counters.
        /// </remarks>
        void OnEventWritten(EventCounterData eventCounterData);

        /// <summary>
        /// Called periodically to update the health status for the web application.
        /// </summary>
        /// <param name="data">Add status details to this dictionary</param>
        /// <returns>The health status of this event counter</returns>
        HealthStatus UpdateHealthStatus(Dictionary<string, object> data);
    }
}
