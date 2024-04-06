using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Data.Models
{
    public class Image
    {
        /// <summary>
        /// Сгенерированная ссылка
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Название локации, которое должно быть найдено
        /// </summary>
        public string AllegedLocation { get; set; }
    }
}
