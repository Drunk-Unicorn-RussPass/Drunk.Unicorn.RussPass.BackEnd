using Drunk.Unicorn.RussPass.Kafka;
using Drunk.Unicorn.RussPass.Kafka.Config;
using Drunk.Unicorn.RussPass.Users.BI.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.BI.Services
{
    public class Check : ICheck
    {
        private readonly IKafkaProvider _kafka;
        private readonly IFilesProvider _files;
        private readonly KafkaConfig _config;

        public Check(IKafkaProvider kafka, IFilesProvider files/*IOptions<KafkaConfig> config*/)
        {
            _files = files;
            _kafka = kafka;
            _config = new KafkaConfig();
        }

        public async Task SendImage(MemoryStream image, string fileName, int locationId, int trackId)
        {
            var url = await _files.SendFile(image, fileName);

            await _kafka.Produce(_config.MainTopic, JsonSerializer.Serialize(new
            {
                Url = url,
                LocationId = locationId,
                TrackId = trackId,
            }));
        }

        public async Task<string> SendImageReturnUrl(MemoryStream image, string fileName)
        {
            return await _files.SendFile(image, fileName);
        }
    }
}
