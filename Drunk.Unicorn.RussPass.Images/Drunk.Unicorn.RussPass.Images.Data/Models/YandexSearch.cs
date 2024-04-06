﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.Data.Models
{
    public class YandexSearch : SearchBase
    {
        public YandexSearch() : base("yandex_images") { }

        /// <summary>
        /// Url изображения
        /// </summary>
        [DisplayName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Ключ Api
        /// </summary>
        [DisplayName("api_key")]
        public string Key { get; set; }
    }

    public class SearchBase
    {
        private readonly string typeSearch;

        /// <summary>
        /// Тип движка поиска
        /// </summary>
        [DisplayName("engine")]
        private string TypeSearch => typeSearch;

        public SearchBase()
        {
            typeSearch = "google";
        }

        public SearchBase(string type)
        {
            TypeSearch = type;
        }
    }
}
