using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Kafka.Config
{
    public class KafkaConfig
    {
        public string ServersUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Главный топик
        /// </summary>
        public string MainTopic { get; set; }

        /// <summary>
        /// Топик с закоммиченными, но получившими ошибку, данными
        /// </summary>
        public string PassiveTopic { get; set; }
        public string MainGroup { get; set; }
        public string MessageTimeoutMs { get; set; }
    }
}
