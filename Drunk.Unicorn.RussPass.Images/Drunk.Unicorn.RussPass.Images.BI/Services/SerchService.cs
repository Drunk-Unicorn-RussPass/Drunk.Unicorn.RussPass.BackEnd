using Drunk.Unicorn.RussPass.Images.BI.Interfaces;
using Drunk.Unicorn.RussPass.Images.Data.Models;
using Drunk.Unicorn.RussPass.Images.General.Exceptions;
using Drunk.Unicorn.RussPass.Images.General.Expansions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drunk.Unicorn.RussPass.Images.BI.Services;

public class SerpClient : ISearchClient
{
    private readonly HttpClient _httpClient;

    public SerpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TResult> Search<TResult, TSearch>(TSearch value) where TSearch : SearchBase
    {
        var response = await _httpClient.GetAsync(_httpClient.BaseAddress.BuildUrlWithQueryStringUsingStringConcat(value.ToDictionary()));

        var json = await response.Content.ReadAsStringAsync();

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return JsonSerializer.Deserialize<TResult>(json, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });
        }

        throw new SearchException(json, response.StatusCode);
    }
}