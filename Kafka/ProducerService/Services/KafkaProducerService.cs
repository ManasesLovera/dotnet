using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using ProducerService.Interfaces;

namespace ProducerService.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IProducer<string, string> _producer;
        private readonly ILogger<KafkaProducerService> _logger;
        private readonly string _bootstrapServers;
        public KafkaProducerService(ILogger<KafkaProducerService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _bootstrapServers = configuration["Kafka:BootstrapServers"] ?? throw new ArgumentNullException("Kafka:BoostrampServers is missing in configuration");
            
            var config = new ProducerConfig
            {
                BootstrapServers = _bootstrapServers,
                AllowAutoCreateTopics = true,
                Acks = Acks.All
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task SendMessageAsync(string topic, string key, string message, CancellationToken cancellationToken = default)
        {
            try {
                var msg = new Message<string, string> { Key = key, Value = message };
                await _producer.ProduceAsync(topic, msg, cancellationToken);
                _logger.LogInformation($"Kafka Message Sent: Topic={topic}, Key={key}, Value={message}. \n{DateTime.UtcNow.ToString("yyyy-MM-dd")}");
            }
            catch (ProduceException<string, string> e) 
            {
                _logger.LogError($"Delivery failed: {e.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending message to Kafka");
                throw;
            }
            _producer.Flush(cancellationToken);
        }
    }
}