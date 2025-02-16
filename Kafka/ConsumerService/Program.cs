using ConsumerService.Interfaces;
using ConsumerService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(configHost =>
    {
        configHost.SetBasePath(Directory.GetCurrentDirectory());
        configHost.AddJsonFile("appsettings.json", optional: true);
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<IKafkaConsumerService, KafkaConsumerService>();
        services.AddLogging(config => config.AddConsole());
    })
    .UseSerilog( (context, configuration) =>
    {
        configuration.ReadFrom.Configuration(context.Configuration);
    })
    .Build();

var logger = host.Services.GetService<ILogger<Program>>() ?? throw new Exception("Serilog is not set correctly");

logger.LogInformation("Consumer listening...");

var consumerService = host.Services.GetRequiredService<IKafkaConsumerService>();

await consumerService.ConsumeMessagesAsync(CancellationToken.None);