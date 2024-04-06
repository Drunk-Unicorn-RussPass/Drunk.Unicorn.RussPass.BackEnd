using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Drunk.Unicorn.RussPass.Images.General.Expansions
{
    public static class UriExpansions
    {

        /// <summary>
        /// Добавить базовому адресу параметры
        /// </summary>
        /// <param name="baseUrl">Базовый адрес</param>
        /// <param name="queryParams">Словарь из параметров</param>
        /// <returns>Возвращает null если baseUrl = null</returns>
        public static Uri? BuildUrlWithQueryStringUsingStringConcat(
                    this Uri? baseUrl, Dictionary<string, string> queryParams)
        {
            if (baseUrl is null)
                return null;

            var queryString = string.Join("&",
                queryParams.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
            return new Uri($"{baseUrl}?{queryString}");
        }
    }
}
