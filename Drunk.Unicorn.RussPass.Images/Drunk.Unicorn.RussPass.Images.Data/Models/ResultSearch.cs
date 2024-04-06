using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.Data.Models
{
    public class ResultSearch
    {
        [JsonProperty("image_tags")]
        public Tag[] ImageTags { get; set; }

        public bool IsExistLocationName(string locationName)
        {
            var words = locationName..Split(' ');

            return words.All()
        }
    }
}
