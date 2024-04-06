using Drunk.Unicorn.RussPass.Data.Models;
using Drunk.Unicorn.RussPass.Images.BI.Interfaces;
using Drunk.Unicorn.RussPass.Images.BI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Drunk.Unicorn.RussPass.Images.General.Expansions;
using Drunk.Unicorn.RussPass.Images.Data.Models;
using System.Text.Json;
using System.Security.Cryptography;

namespace Drunk.Unicorn.RussPass.Images.BI.Services
{
    public class Search : ISearch
    {
        private readonly HttpClient _httpClient;

        public Search(HttpClient client, Config config)
        {
            _httpClient = client;

            _httpClient.BaseAddress = new Uri(config.SerpUrl);
        }

        public async Task<bool> FindImageAsync(YandexSearch search)
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress.BuildUrlWithQueryStringUsingStringConcat(search.ToDictionary()));
        
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ResultSearch>(json);

                if(result?.ImageTags is null)
                {
                    search.Key = Keys.Next();

                    return await FindImageAsync(search);
                }
            }
        }
    }
}
