using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using ConsumerService.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsumerService.Services
{
    public class KafkaConsumerService : IKafkaConsumerService
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly ILogger<KafkaConsumerService> _logger;
        private readonly string _topic;

        public KafkaConsumerService(ILogger<KafkaConsumerService> logger, IConfiguration configuration)
        {
            _logger = logger;
            var config = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"] ?? throw new ArgumentNullException("Kafka:BootstrapServers is missing in appsettings.json"),
                GroupId = "consumer-group-1",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _topic = "my-topic";
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task ConsumeMessagesAsync(CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            _consumer.Subscribe(_topic);
            _logger.LogInformation("Subscribed to topic: {Topic}", _topic);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = _consumer.Consume(cancellationToken);
                    _logger.LogInformation($"Received message: Key={result.Message.Key}, Value={result.Message.Value}");
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Consumer stopped.");
            }
            finally
            {
                _consumer.Close();
            }
        }
    }
}