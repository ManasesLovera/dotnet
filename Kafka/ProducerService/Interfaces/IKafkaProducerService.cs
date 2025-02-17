using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProducerService.Interfaces
{
    public interface IKafkaProducerService
    {
        Task SendMessageAsync(string topic, string key, string message, CancellationToken cancellationToken = default);
    }
}