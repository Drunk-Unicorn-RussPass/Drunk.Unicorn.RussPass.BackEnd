using AutoMapper;
using Confluent.Kafka;
using Drunk.Unicorn.RussPass.Images.BI.Interfaces;
using Drunk.Unicorn.RussPass.Images.Data.Models;
using Drunk.Unicorn.RussPass.Images.General.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using static Confluent.Kafka.ConfigPropertyNames;

namespace Drunk.Unicorn.RussPass.Images.Kafka
{
    internal class KafkaService
    {
        private readonly ISearch _search;
        private readonly ILocations _locations;

        public KafkaService(IServiceProvider services)
        {
            using (var scp = services.CreateScope())
            {
                _locations = scp.ServiceProvider.GetRequiredService<ILocations>();
                _search = scp.ServiceProvider.GetRequiredService<ISearch>();
            }
        }

        private YandexSearch Deserialize(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<YandexSearch>(json);
            }
            catch
            {
                return null;
            }
        }

        public Task DoWork(IConsumer<Null, string>? consumer, CancellationToken stoppingToken)
        {
            Task.Run(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(10, stoppingToken);

#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                        var record = consumer.Consume(stoppingToken);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.

                        if (record is null || record.Message is null || string.IsNullOrEmpty(record.Message.Value))
                        {
                            Commit(consumer);
                            continue;
                        }

                        var model = Deserialize(record.Message.Value);

                        if (model is null)
                        {
                            Commit(consumer);
                            continue;
                        }

                        await _search.FindImageAsync(model);
                        await _location.SetStatus(model.LocationId, model.TrackId);
                       
                    }
                    catch (SearchException ex)
                    {
                        //Логгер
                    }
                    catch (KafkaException ex)
                    {
                        //Логгер
                    }
                    catch (Exception ex)
                    {
                        //Логгер
                    }
                    finally
                    {
                        Commit(consumer);
                    }
                }

            }, stoppingToken);

            return Task.CompletedTask;
        }

        private void Commit(IConsumer<Null, string>? consumer)
        {
            try
            {
                consumer?.Commit();
            }
            catch
            {

            }
        }
    }
}
