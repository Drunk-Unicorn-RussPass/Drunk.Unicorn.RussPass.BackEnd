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
using Drunk.Unicorn.RussPass.Images.General.Exceptions;

namespace Drunk.Unicorn.RussPass.Images.BI.Services
{
    public class Search : ISearch
    {
        private readonly ISearchClient _httpClient;
        private readonly Keys _keys;

        public Search(ISearchClient httClient, Keys keys)
        {
            _httpClient = httClient;
            _keys = keys;
        }

        public async Task<bool> FindImageAsync(YandexSearch request)
        {
            try
            {
                var result = await _httpClient.Search<ResultSearch, YandexSearch>(request);
                if (result?.image_tags?.Any() != true)
                    throw new SearchException("Не удалось распознать изображение!", System.Net.HttpStatusCode.OK);

                return result.IsExistLocationName(request.LocationName);
            }
            catch (SearchKeyNotValidException)
            {
                request.Key = _keys.GetNextKey();

                return await FindImageAsync(request);
            }
            catch(Exception e)
            {
                Console.WriteLine();
                throw;
            }
        }
    }
}
