using System.Threading.Tasks;

namespace PavementCondition.UI.Infrastructure
{
    public interface IApiClient
    {
        Task<TResponse> GetAsync<TResponse>(string url);

        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string url);

        Task<TResponse> PutAsync<TRequest, TResponse>(TRequest request, string url);

        Task DeleteAsync<TRequest>(TRequest request, string url);
    }
}
