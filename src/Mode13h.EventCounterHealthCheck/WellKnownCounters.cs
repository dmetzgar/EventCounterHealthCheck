namespace Mode13h.EventCounterHealthCheck
{
    /// <summary>
    /// A list of the event source and counter names for all the well-known .NET event counters. Refer to 
    /// <see href="https://docs.microsoft.com/dotnet/core/diagnostics/available-counters">Well-known Counters in .NET</see>
    /// for more information.
    /// </summary>
    public static class WellKnownCounters
    {
        /// <summary>
        /// System.Runtime counters published as part of .NET runtime (CoreCLR) and maintained in 
        /// <see href="https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Diagnostics/Tracing/RuntimeEventSource.cs">RuntimeEventSource.cs</see>
        /// </summary>
        public static class SystemRuntime
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "System.Runtime";

            /// <summary>
            /// The number of Timer instances that are currently active, based on <see cref="System.Threading.Timer.ActiveCount"/>
            /// </summary>
            public const string ActiveTimeCounter = "active-timer-count";

            /// <summary>
            /// The number of bytes allocated per update interval
            /// </summary>
            public const string AllocRate = "alloc-rate";

            /// <summary>
            /// The number of <see cref="System.Reflection.Assembly"/> instances loaded into a process at a point in time
            /// </summary>
            public const string AssemblyCount = "assembly-count";

            /// <summary>
            /// The percent of the process's CPU usage relative to all of the system CPU resources
            /// </summary>
            public const string CpuUsage = "cpu-usage";

            /// <summary>
            /// The number of exceptions that have occurred
            /// </summary>
            public const string ExceptionCount = "exception-count";

            /// <summary>
            /// The number of bytes committed by the GC
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 6
            /// </remarks>
            public const string GcCommittedBytes = "gc-committed-bytes";

            /// <summary>
            /// The GC Heap Fragmentation
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string GcFragmentation = "gc-fragmentation";

            /// <summary>
            /// The number of bytes thought to be allocated based on <see cref="System.GC.GetTotalMemory(bool)"/>
            /// </summary>
            public const string GcHeapSize = "gc-heap-size";

            /// <summary>
            /// The number of times GC has occurred for Gen 0 per update interval
            /// </summary>
            public const string Gen0GcCount = "gen-0-gc-count";

            /// <summary>
            /// The number of bytes for Gen 0 GC
            /// </summary>
            public const string Gen0Size = "gen-0-size";

            /// <summary>
            /// The number of times GC has occurred for Gen 1 per update interval
            /// </summary>
            public const string Gen1GcCount = "gen-1-gc-count";

            /// <summary>
            /// The number of bytes for Gen 1 GC
            /// </summary>
            public const string Gen1Size = "gen-1-size";

            /// <summary>
            /// The number of times GC has occurred for Gen 2 per update interval
            /// </summary>
            public const string Gen2GcCount = "gen-2-gc-count";

            /// <summary>
            /// The number of bytes for Gen 2 GC
            /// </summary>
            public const string Gen2Size = "gen-2-size";

            /// <summary>
            /// The total size of ILs that are JIT-compiled, in bytes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string IlBytesJitted = "il-bytes-jitted";

            /// <summary>
            /// The number of bytes for the large object heap
            /// </summary>
            public const string LohSize = "loh-size";

            /// <summary>
            /// The number of methods that are JIT-compiled	
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string MethodJittedCount = "method-jitted-count";

            /// <summary>
            /// The number of times there was contention when trying to take the monitor's lock, based on
            /// <see cref="System.Threading.Monitor.LockContentionCount" />
            /// </summary>
            public const string MonitorLockContentionCount = "monitor-lock-contention-count";

            /// <summary>
            /// The number of bytes for the pinned object heap
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string PohSize = "poh-size";

            /// <summary>
            /// The number of work items that have been processed so far in the <see cref="System.Threading.ThreadPool"/>
            /// </summary>
            public const string ThreadPoolCompletedWorkItemCount = "threadpool-completed-items-count";

            /// <summary>
            /// The number of work items that are currently queued to be processed in the <see cref="System.Threading.ThreadPool"/>
            /// </summary>
            public const string ThreadPoolQueueLength = "threadpool-queue-length";

            /// <summary>
            /// The number of thread pool threads that currently exist in the <see cref="System.Threading.ThreadPool"/>, 
            /// based on <see cref="System.Threading.ThreadPool.ThreadCount"/>
            /// </summary>
            public const string ThreadPoolThreadCount = "threadpool-thread-count";

            /// <summary>
            /// The percent of time in GC since the last GC
            /// </summary>
            public const string TimeInGc = "time-in-gc";

            /// <summary>
            /// The amount of physical memory mapped to the process context at a point in time based on <see cref="System.Environment.WorkingSet"/>
            /// </summary>
            public const string WorkingSet = "working-set";
        }

        /// <summary>
        /// Counters published as part of ASP.NET Core and maintained in 
        /// <see href="https://github.com/dotnet/aspnetcore/blob/main/src/Hosting/Hosting/src/Internal/HostingEventSource.cs">HostingEventSource.cs</see>.
        /// </summary>
        public static class AspNetCoreHosting
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "Microsoft.AspNetCore.Hosting";

            /// <summary>
            /// The total number of requests that have started, but not yet stopped
            /// </summary>
            public const string CurrentRequests = "current-requests";

            /// <summary>
            /// The total number of failed requests that have occurred for the life of the app
            /// </summary>
            public const string FailedRequests = "failed-requests";

            /// <summary>
            /// The number of requests that occur per update interval
            /// </summary>
            public const string RequestRate = "request-rate";

            /// <summary>
            /// The total number of requests that have occurred for the life of the app
            /// </summary>
            public const string TotalRequests = "total-requests";
        }

        /// <summary>
        /// Counters published as part of ASP.NET Core SignalR and maintained in 
        /// <see href="https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/common/Http.Connections/src/Internal/HttpConnectionsEventSource.cs">HttpConnectionsEventSource.cs</see>.
        /// </summary>
        public static class AspNetCoreSignalRHttpConnections
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "Microsoft.AspNetCore.Http.Connections";

            /// <summary>
            /// The average duration of a connection in milliseconds
            /// </summary>
            public const string AverageConnectionDuration = "connections-duration";

            /// <summary>
            /// The number of active connections that have started, but not yet stopped
            /// </summary>
            public const string CurrentConnections = "current-connections";

            /// <summary>
            /// The total number of connections that have started
            /// </summary>
            public const string TotalConnectionsStarted = "connections-started";

            /// <summary>
            /// The total number of connections that have stopped
            /// </summary>
            public const string TotalConnectionsStopped = "connections-stopped";

            /// <summary>
            /// The total number of connections that have timed out
            /// </summary>
            public const string TotalConnectionsTimedOut = "connections-timed-out";
        }

        /// <summary>
        /// Counters published as part of the ASP.NET Core Kestrel web server and maintained in 
        /// <see href="https://github.com/dotnet/aspnetcore/blob/main/src/Servers/Kestrel/Core/src/Internal/Infrastructure/KestrelEventSource.cs">KestrelEventSource.cs</see>.
        /// </summary>
        /// <remarks>
        /// Available starting with .NET 5
        /// </remarks>
        public static class AspNetCoreKestrel
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "Microsoft-AspNetCore-Server-Kestrel";

            /// <summary>
            /// The current length of the connection queue
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string ConnectionQueueLength = "connection-queue-length";

            /// <summary>
            /// The number of connections per update interval to the web server
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string ConnectionRate = "connections-per-second";

            /// <summary>
            /// The current number of active connections to the web server
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string CurrentConnections = "current-connnections";

            /// <summary>
            /// The current number of TLS handshakes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string CurrentTlsHandshakes = "current-tls-handshakes";

            /// <summary>
            /// The current number of upgraded requests (WebSockets)
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string CurrentUpgradedRequests = "current-upgraded-requests";

            /// <summary>
            /// The total number of failed TLS handshakes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string FailedTlsHandshakes = "failed-tls-handshakes";

            /// <summary>
            /// The current length of the request queue
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string RequestQueueLength = "request-queue-length";

            /// <summary>
            /// The number of TLS handshakes per update interval
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string TlsHandshakeRate = "tls-handshakes-per-second";

            /// <summary>
            /// The total number of connections to the web server
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string TotalConnections = "total-connections";

            /// <summary>
            /// The total number of TLS handshakes with the web server
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string TotalTlsHandshakes = "total-tls-handshakes";
        }

        /// <summary>
        /// Counters published by the HTTP stack.
        /// </summary>
        /// <remarks>
        /// Available starting with .NET 5
        /// </remarks>
        public static class SystemNetHttp
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "System.Net.Http";

            /// <summary>
            /// The current number of HTTP 1.1 connections that have started but not yet completed or failed
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string CurrentHttp11Connections = "http11-connections-current-total";

            /// <summary>
            /// The current number of HTTP 2.0 connections that have started but not yet completed or failed
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string CurrentHttp20Connections = "http20-connections-current-total";

            /// <summary>
            /// Current number of active HTTP requests that have started but not yet completed or failed
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string CurrentRequests = "current-requests";

            /// <summary>
            /// The average duration of the time HTTP 1.1 requests spent in the request queue
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Http11RequestsQueueDuration = "http11-requests-queue-duration";

            /// <summary>
            /// The average duration of the time HTTP 2.0 requests spent in the request queue
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Http20RequestsQueueDuration = "http20-requests-queue-duration";

            /// <summary>
            /// The number of failed requests since the process started	
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string RequestsFailed = "requests-failed";

            /// <summary>
            /// The number of failed requests per update interval
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string RequestsFailedRate = "requests-failed-rate";

            /// <summary>
            /// The number of requests started since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string RequestsStarted = "requests-started";

            /// <summary>
            /// The number of requests started per update interval
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string RequestsStartedRate = "requests-started-rate";
        }

        /// <summary>
        /// Counters to track metrics related to DNS lookups.
        /// </summary>
        /// <remarks>
        /// Available starting with .NET 5
        /// </remarks>
        public static class SystemNetNameResolution
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "System.Net.NameResolution";

            /// <summary>
            /// The average time taken for a DNS lookup
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string AverageDnsLookupDuration = "dns-lookups-duration";

            /// <summary>
            /// The number of DNS lookups requested since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string DnsLookupsRequested = "dns-lookups-requested";
        }

        /// <summary>
        /// Counters to track metrics related to the Transport Layer Security protocol.
        /// </summary>
        /// <remarks>
        /// Available starting with .NET 5
        /// </remarks>
        public static class SystemNetSecurity
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "System.Net.Security";

            /// <summary>
            /// The number of active TLS sessions of any version
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string AllTlsSessionsActive = "all-tls-sessions-open";

            /// <summary>
            /// The current number of TLS handshakes that have started but not yet completed
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string CurrentTlsHandshakes = "current-tls-handshakes";

            /// <summary>
            /// The average duration of TLS 1.0 handshakes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls10HandshakeDuration = "tls10-handshake-duration";

            /// <summary>
            /// The number of active TLS 1.0 sessions
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls10SessionsActive = "tls10-sessions-open";

            /// <summary>
            /// The average duration of TLS 1.1 handshakes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls11HandshakeDuration = "tls11-handshake-duration";

            /// <summary>
            /// The number of active TLS 1.1 sessions
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls11SessionsActive = "tls11-sessions-open";

            /// <summary>
            /// The average duration of TLS 1.2 handshakes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls12HandshakeDuration = "tls12-handshake-duration";

            /// <summary>
            /// The number of active TLS 1.2 sessions
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls12SessionsActive = "tls12-sessions-open";

            /// <summary>
            /// The average duration of TLS 1.3 handshakes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls13HandshakeDuration = "tls13-handshake-duration";

            /// <summary>
            /// The number of active TLS 1.3 sessions
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string Tls13SessionsActive = "tls13-sessions-open";

            /// <summary>
            /// The average duration of all TLS handshakes
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string TlsHandshakeDuration = "all-tls-handshake-duration";

            /// <summary>
            /// The number of TLS handshakes completed per update interval
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string TlsHandshakeRate = "tls-handshake-rate";

            /// <summary>
            /// The total number of TLS handshakes completed since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string TotalTlsHandshakesCompleted = "total-tls-handshakes";

            /// <summary>
            /// The total number of failed TLS handshakes since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string TotalTlsHandshakesFailed = "failed-tls-handshakes";
        }

        /// <summary>
        /// Counters to track metrics related to <see cref="System.Net.Sockets.Socket"/>.
        /// </summary>
        /// <remarks>
        /// Available starting with .NET 5
        /// </remarks>
        public static class SystemNetSockets
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "System.Net.Sockets";

            /// <summary>
            /// The total number of bytes received since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string BytesReceived = "bytes-received";

            /// <summary>
            /// The total number of bytes sent since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string BytesSent = "bytes-sent";

            /// <summary>
            /// The total number of datagrams received since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string DatagramsReceived = "datagrams-received";

            /// <summary>
            /// The total number of datagrams sent since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string DatagramsSent = "datagrams-sent";

            /// <summary>
            /// The total number of incoming connections established since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string IncomingConnectionsEstablished = "incoming-connections-established";

            /// <summary>
            /// The total number of outgoing connections established since the process started
            /// </summary>
            /// <remarks>
            /// Available starting with .NET 5
            /// </remarks>
            public const string OutgoingConnectionsEstablished = "outgoing-connections-established";
        }

        /// <summary>
        /// Counters published as part of Microsoft.Data.SqlClient, which is used by Entity Framework Core. Refer to 
        /// <see href="https://github.com/dotnet/SqlClient/blob/main/src/Microsoft.Data.SqlClient/src/Microsoft/Data/SqlClient/SqlClientEventSource.cs">SqlClientEventSource.cs</see>
        /// for more information.
        /// </summary>
        /// <remarks>
        /// Counters are also documented in the 
        /// <see href="https://github.com/dotnet/SqlClient/blob/1e8ce9766c79b12f7835a8679058d9bce41f7dbc/release-notes/3.0/3.0.0.md#event-counters">release notes</see>.
        /// </remarks>
        public static class SqlClient
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "Microsoft.Data.SqlClient.EventSource";

            /// <summary>
            /// The number of unique connection pool groups that are active. This counter is controlled by the number of unique connection strings that are found in the AppDomain.
            /// </summary>
            public const string ActiveConnectionPoolGroups = "number-of-active-connection-pool-groups";

            /// <summary>
            /// The total number of connection pools.
            /// </summary>
            public const string ActiveConnectionPools = "number-of-active-connection-pools";

            /// <summary>
            /// The number of active connections that are currently in use.
            /// </summary>
            public const string ActiveConnections = "number-of-active-connections";

            /// <summary>
            /// The number of connections that are currently open to database servers.
            /// </summary>
            public const string ActiveHardConnections = "active-hard-connections";

            /// <summary>
            /// The number of active connections that aren't pooled.
            /// </summary>
            public const string ActiveNonPooledConnections = "number-of-non-pooled-connections";

            /// <summary>
            /// The number of active connections that are being managed by the connection pooling infrastructure.
            /// </summary>
            public const string ActivePooledConnections = "number-of-pooled-connections";

            /// <summary>
            /// The number of already-open connections being consumed from the connection pool.
            /// </summary>
            public const string ActiveSoftConnections = "active-soft-connects";

            /// <summary>
            /// The number of open connections available for use in the connection pools.
            /// </summary>
            public const string FreeConnections = "number-of-free-connections";

            /// <summary>
            /// The number of connections per second that are being opened to database servers.
            /// </summary>
            public const string HardConnectionRate = "hard-connects";

            /// <summary>
            /// The number of disconnects per second that are being made to database servers.
            /// </summary>
            public const string HardDisconnectionRate = "hard-disconnects";

            /// <summary>
            /// The number of unique connection pool groups that are marked for pruning. This counter is controlled by the number of unique connection strings that are found in the AppDomain.
            /// </summary>
            public const string InactiveConnectionPoolGroups = "number-of-inactive-connection-pool-groups";

            /// <summary>
            /// The number of inactive connection pools that haven't had any recent activity and are waiting to be disposed.
            /// </summary>
            public const string InactiveConnectionPools = "number-of-inactive-connection-pools";

            /// <summary>
            /// The number of connections that have been reclaimed through garbage collection where Close or Dispose wasn't called by the application.
            /// </summary>
            /// <remarks>
            /// Note that not explicitly closing or disposing connections hurts performance.
            /// </remarks>
            public const string ReclaimedConnections = "number-of-reclaimed-connections";

            /// <summary>
            /// The number of connections per second that are being consumed from the connection pool.
            /// </summary>
            public const string SoftConnectionsRate = "soft-connects";

            /// <summary>
            /// The number of connections per second that are being returned to the connection pool.
            /// </summary>
            public const string SoftDisconnectionRate = "soft-disconnects";

            /// <summary>
            /// The number of connections currently awaiting completion of an action and which are unavailable for use by the application.
            /// </summary>
            public const string StatisConnections = "number-of-stasis-connections";
        }

        /// <summary>
        /// Counters for Entity Framework. Refer to <see href="https://github.com/dotnet/efcore/blob/main/src/EFCore/Infrastructure/EntityFrameworkEventSource.cs">EntityFrameworkEventSource.cs</see>
        /// for more information.
        /// </summary>
        public static class EntityFramework
        {
            /// <summary>
            /// Name of the EventSource for this set of counters
            /// </summary>
            public const string EventSourceName = "Microsoft.EntityFrameworkCore";

            /// <summary>
            /// Active DbContexts
            /// </summary>
            public const string ActiveDbContexts = "active-db-contexts";

            /// <summary>
            /// Compiler query cache hit rate percentage
            /// </summary>
            public const string CompiledQueryCacheHitRate = "compiled-query-cache-hit-rate";

            /// <summary>
            /// Execution strategy operation failure rate
            /// </summary>
            public const string ExecutionStrategyOperationFailureRate = "execution-strategy-operation-failures-per-second";

            /// <summary>
            /// Optimistic concurrency failure rate
            /// </summary>
            public const string OptimisticConcurrencyFailureRate = "optimistic-concurrency-failures-per-second";

            /// <summary>
            /// Queries rate
            /// </summary>
            public const string QueriesRate = "queries-per-second";

            /// <summary>
            /// SaveChanges rate
            /// </summary>
            public const string SaveChangesRate = "save-changes-per-second";

            /// <summary>
            /// Total execution strategy operation failures
            /// </summary>
            public const string TotalExecutionStrategyOperationFailures = "total-execution-strategy-operation-failures";

            /// <summary>
            /// Total optimistic concurrency failures
            /// </summary>
            public const string TotalOptimisticConcurrencyFailures = "total-optimistic-concurrency-failures";

            /// <summary>
            /// Total queries
            /// </summary>
            public const string TotalQueries = "total-queries";

            /// <summary>
            /// Total SaveChanges calls
            /// </summary>
            public const string TotalSaveChanges = "total-save-changes";
        }
    }
}
