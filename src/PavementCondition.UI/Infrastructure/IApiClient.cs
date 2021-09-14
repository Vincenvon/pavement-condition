using System.Threading.Tasks;

namespace PavementCondition.UI.Infrastructure
{
    public interface IApiClient
    {
        Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request);
    }
}
