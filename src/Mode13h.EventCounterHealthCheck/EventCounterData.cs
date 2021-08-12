using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Mode13h.EventCounterHealthCheck
{
    /// <summary>
    /// Represents an Event Counter metric event
    /// </summary>
    public class EventCounterData
    {
        /// <summary>
        /// Name of the event source emitting the event
        /// </summary>
        public string EventSourceName { get; private set; }

        /// <summary>
        /// Id of the event source emitting the event
        /// </summary>
        public Guid EventSourceGuid { get; private set; }

        /// <summary>
        /// Name of the event counter.
        /// </summary>
        /// <remarks>
        /// Counter names are usually lowercase with dashes and without spaces. Example: cpu-usage
        /// </remarks>
        public string Name { get => GetPayloadItem<string>(); }

        /// <summary>
        /// Display name of the event counter
        /// </summary>
        public string DisplayName { get => GetPayloadItem<string>(); }

        /// <summary>
        /// Mean value of the counter over the interval
        /// </summary>
        public double Mean { get => GetPayloadItem<double>(); }

        /// <summary>
        /// Standard deviation from the mean counter value over the interval
        /// </summary>
        public double StandardDeviation { get => GetPayloadItem<double>(); }

        /// <summary>
        /// Number of samples collected during the interval
        /// </summary>
        public int Count { get => GetPayloadItem<int>(); }

        /// <summary>
        /// Minimum value of the counter over the interval
        /// </summary>
        public double Min { get => GetPayloadItem<double>(); }

        /// <summary>
        /// Maximum value of the counter over the interval
        /// </summary>
        public double Max { get => GetPayloadItem<double>(); }

        /// <summary>
        /// Measured time in seconds for the last interval
        /// </summary>
        public float IntervalSec { get => GetPayloadItem<float>(); }

        /// <summary>
        /// String representation of the series
        /// </summary>
        /// <remarks>
        /// Indicates the configured interval instead of the actual.Example: Interval=1000
        /// </remarks>
        public string Series { get => GetPayloadItem<string>(); }

        /// <summary>
        /// Counter type
        /// </summary>
        /// <remarks>
        /// Example: Mean, Sum
        /// </remarks>
        public string CounterType { get => GetPayloadItem<string>(); }

        /// <summary>
        /// Metadata attached to the counter
        /// </summary>
        public string Metadata { get => GetPayloadItem<string>(); }

        /// <summary>
        /// Unit of the counter values
        /// </summary>
        /// <remarks>
        /// Examples: B, MB, %
        /// </remarks>
        public string DisplayUnits { get => GetPayloadItem<string>(); }

        /// <summary>
        /// The original payload dictionary from the event
        /// </summary>
        public IDictionary<string, object> Payload { get; private set; }

        /// <summary>
        /// Created with the payload extracted from the event
        /// </summary>
        /// <param name="eventSourceName">Event source name</param>
        /// <param name="eventSourceGuid">Event source GUID</param>
        /// <param name="payload">Event counter payload</param>
        /// <remarks>
        /// Constructor is public for unit testing purposes.
        /// </remarks>
        public EventCounterData(string eventSourceName, Guid eventSourceGuid, IDictionary<string, object> payload)
        {
            EventSourceName = eventSourceName;
            EventSourceGuid = eventSourceGuid;
            Payload = payload;
        }

        private T GetPayloadItem<T>([CallerMemberName] string propertyName = "")
        {
            T val = default(T);
            if (Payload.TryGetValue(propertyName, out object obj))
            {
                val = (T)obj;
            }

            return val;
        }
    }
}
