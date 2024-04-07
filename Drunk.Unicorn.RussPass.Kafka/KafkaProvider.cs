using Confluent.Kafka;
using Drunk.Unicorn.RussPass.Kafka.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Kafka
{
    public interface IKafkaProvider : IDisposable
    {
        Task Produce(string topic, string message);
    }

    public class KafkaProvider : IKafkaProvider
    {
        private readonly KafkaConfig _config;
        private readonly IProducer<Null, string> Producer;
        private readonly ILogger<KafkaProvider> _logger;
        private IConsumer<Null, string>? Consumer = null;

        public KafkaProvider(ILogger<KafkaProvider> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration.GetSection("Endpoints").Get<KafkaConfig>();
            if (_config is null)
                return;

            var config = new ProducerConfig
            {
                BootstrapServers = _config.ServersUrl,
                MessageTimeoutMs = Convert.ToInt32(_config.MessageTimeoutMs),
            };

            Producer = new ProducerBuilder<Null, string>(config).SetErrorHandler((producer, error) =>
            {
                _logger.LogError($"Producer error: {error.Reason}");
            }).Build();
        }

        public Task Produce(string topic, string message)  => Producer.ProduceAsync(topic, new Message<Null, string> { Value = message });

        public IKafkaProvider Subscribe(string topic)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _config.ServersUrl,
                GroupId = _config.MainGroup,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            Consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();
            Consumer.Subscribe(topic);
            return this;
        }

        public ConsumeResult<Null, string>? Consume()
        {
            ConsumeResult<Null, string>? consumeResult = null;

            try
            {
                consumeResult = Consumer.Consume();
                _logger.LogInformation("New message from kafka: {message} ({time})", consumeResult.Message.Value, DateTime.Now.Millisecond);
            }
            catch (ConsumeException e)
            {
                _logger.LogError($"ConsumeException: {e.Error.Reason}");
                if (e.Error.IsFatal)
                {
                    _logger.LogError($"ConsumeException fatal error: {e.Error.Reason}");
                }
            }

            return consumeResult;
        }

        public void Dispose()
        {
            Producer?.Dispose();
            Consumer?.Dispose();
        }
    }
}
