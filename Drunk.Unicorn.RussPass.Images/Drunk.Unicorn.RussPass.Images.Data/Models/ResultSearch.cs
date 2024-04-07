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

        /// <summary>
        /// Проверка, существует ли хотя бы один искомый тег содержащий название локации.
        /// </summary>
        /// <param name="locationName">Имя локации</param>
        /// <returns></returns>
        public bool IsExistLocationName(string locationName)
        {
            var words = locationName.Split(' ');

            return ImageTags.Select(x => x.Text.Split(' ')).Any(tag => !words.Except(tag).Any());
        }
    }
}
