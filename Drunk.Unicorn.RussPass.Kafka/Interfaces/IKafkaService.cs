using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Kafka.Interfaces
{
    public interface IKafkaService
    {
        Task DoWork(IConsumer<Null, string>? consumer, CancellationToken stoppingToken = default);
    }
}
