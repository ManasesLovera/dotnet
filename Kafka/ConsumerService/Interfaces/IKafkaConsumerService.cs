using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace ConsumerService.Interfaces
{
    public interface IKafkaConsumerService
    {
        Task ConsumeMessagesAsync(CancellationToken cancellationToken);
    }
}