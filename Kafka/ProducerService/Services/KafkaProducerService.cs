using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace ProducerService.Services
{
    public class KafkaProducerService
    {
        private readonly IProducer<string, string> _producer;
        private readonly ILogger<KafkaProducerService> _logger;
        public KafkaProducerService(ILogger<KafkaProducerService> logger)
        {
            _logger = logger;
            var config = new ProducerConfig
            {
                BootstrapServers = "kafka:9092"
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task SendMessageAsync(string topic, string key, string message)
        {
            var msg = new Message<string, string> { Key = key, Value = message };
            await _producer.ProduceAsync(topic, msg);
            _logger.LogInformation($"Kafka Message Sent: {message}");
        }
    }
}