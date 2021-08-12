# EventCounter HealthCheck

This is the source repository for the Mode13h.EventCounterHealthCheck NuGet package. This package allows you to 
add a health check to your ASP.NET Core application that is based on 
[EventCounters](https://docs.microsoft.com/azure/azure-monitor/app/eventcounters).

## How to use

There is an example empty ASP.NET Core web application included in this repo for reference.

Add the following to your Startup.ConfigureServices method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...

    services.InitEventCounterHealthCheck();
    services.AddHealthChecks()
        .AddEventCounterHealthCheck();

    services.AddSingleton<IEventCounterFilter>(
        new ThresholdEventCounterFilter(
            WellKnownCounters.AspNetCoreHosting.EventSourceName,
            WellKnownCounters.AspNetCoreHosting.TotalRequests,
            100,
            80,
            ThresholdEventCounterFilter.MaxOrMin.Max));
    services.AddSingleton<IEventCounterFilter>(
        new ThresholdEventCounterFilter(
            WellKnownCounters.SystemRuntime.EventSourceName,
            WellKnownCounters.SystemRuntime.ThreadPoolThreadCount,
            10,
            8,
            ThresholdEventCounterFilter.MaxOrMin.Max));
}
```

`InitEventCounterHealthCheck` registers the event listener and hosted service.
`AddEventCounterHealthCheck` adds the health check but no items will appear on the health report 
until you add a filter. Here are some example filters:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...

    services.AddSingleton<IEventCounterFilter>(
        new ThresholdEventCounterFilter(
            WellKnownCounters.AspNetCoreHosting.EventSourceName,
            WellKnownCounters.AspNetCoreHosting.TotalRequests,
            100,
            80,
            ThresholdEventCounterFilter.MaxOrMin.Max));
    services.AddSingleton<IEventCounterFilter>(
        new ThresholdEventCounterFilter(
            WellKnownCounters.SystemRuntime.EventSourceName,
            WellKnownCounters.SystemRuntime.ThreadPoolThreadCount,
            10,
            8,
            ThresholdEventCounterFilter.MaxOrMin.Max));
}
```

These are based on some of the [Well-known Counters in .NET](https://docs.microsoft.com/en-us/dotnet/core/diagnostics/available-counters).

If you're not familiar with ASP.NET Core health checks, you'll have to add an endpoint:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ...

    app.UseEndpoints(endpoints =>
    {
        //...

        endpoints.MapHealthChecks("/health");
    });
}
```

See the Microsoft document [here](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks) for more information on health checks.
