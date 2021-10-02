
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

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteAsync<TRequest>(TRequest request, string url)
        {
            var message = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Version = new Version(2, 0),
            };

            await _httpClient.SendAsync(message);
        }

        public async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Version = new Version(2, 0),
            };

            var response = await _httpClient.SendAsync(message);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string url)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Version = new Version(2, 0),
                Content = JsonContent.Create(request),
            };

            var response = await _httpClient.SendAsync(message);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(TRequest request, string url)
        {
            var message = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Version = new Version(2, 0),
                Content = JsonContent.Create(request),
            };

            var response = await _httpClient.SendAsync(message);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResponse>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
