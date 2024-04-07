using Confluent.Kafka;
using Drunk.Unicorn.RussPass.Kafka.Config;
using Drunk.Unicorn.RussPass.Kafka.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Kafka
{
    public class KafkaWorker : IHostedService, IDisposable
    {
        private readonly IConsumer<Null, string>? _consumer;
        private readonly ILogger<KafkaWorker> _logger;

        private readonly IServiceProvider _services;

        public KafkaWorker(ILogger<KafkaWorker> logger, IOptions<KafkaConfig> kafkaOption, IServiceProvider services)
        {
            _services = services;
            _logger = logger;
            try
            {
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = kafkaOption.Value.ServersUrl,
                    SecurityProtocol = SecurityProtocol.SaslPlaintext,
                    SaslMechanism = SaslMechanism.Plain,
                    SaslUsername = kafkaOption.Value.Username,
                    SaslPassword = kafkaOption.Value.Password,
                    GroupId = kafkaOption.Value.MainGroup,
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                _consumer = new ConsumerBuilder<Null, string>(consumerConfig).Build();

                _consumer.Subscribe(new[] { kafkaOption.Value.MainTopic, kafkaOption.Value.PassiveTopic });
            }
            catch (Exception ex)
            {

            }
        }

        public async Task StartAsync(CancellationToken stoppingToken = default)
        {
            _logger.LogInformation("Kafka worker started!");

            try
            {
                using (var scp = _services.CreateScope())
                {
                    var kafka = scp.ServiceProvider.GetRequiredService<IKafkaService>();
                    await kafka.DoWork(_consumer, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _consumer?.Close();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _consumer?.Dispose();
        }
    }
}
