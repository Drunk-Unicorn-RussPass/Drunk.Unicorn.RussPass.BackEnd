using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Users.Data.Models
{
    public class ImageObmennik
    {
        public class DataImage
        {
            [JsonProperty("link")]
            public string Link { get; set; }
        };

        [JsonProperty("data")]
        public DataImage Data { get; set; }
    }
}
