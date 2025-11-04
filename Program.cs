// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostBuilder builder = new HostBuilder();
builder.ConfigureWebJobs(options =>
{
    options.AddAzureStorageBlobs();
    options.AddAzureStorageQueues();
});

builder.ConfigureLogging((context, logBuilder) =>
{
    string instrmentationKey = context.Configuration
                                   .GetValue<string>("AppInsights_InstrumentationKey")
                               ?? throw new InvalidOperationException("You should provide instrumentation key");
    logBuilder.AddConsole();
    logBuilder.AddApplicationInsightsWebJobs(options =>
        options.InstrumentationKey = instrmentationKey);
});

IHost host = builder.Build();
using (host)
    await host.RunAsync();
