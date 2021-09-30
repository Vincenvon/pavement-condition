using System.Threading.Tasks;

namespace PavementCondition.UI.Infrastructure
{
    public interface IApiClient
    {

        Task<TResponse> GetAsync<TResponse>(string url);
        
        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request, string url);
    }
}
