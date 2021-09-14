using Microsoft.Extensions.Options;

using PavementCondition.UI.Constants;
using PavementCondition.UI.Settings;

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PavementCondition.UI.Infrastructure
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ApiClientSettings _apiClientSettings;

        public ApiClient(HttpClient httpClient, IOptions<ApiClientSettings> options)
        {
            _httpClient = httpClient;
            _apiClientSettings = options.Value;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post,
                $"{_apiClientSettings.BasePath}${ApiControllerNameConstants.Accounts}/register")
            {
                Version = new Version(2, 0),
                Content = JsonContent.Create(request),
            };

            var response = await _httpClient.SendAsync(message);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(responseString);
        }
    }
}
