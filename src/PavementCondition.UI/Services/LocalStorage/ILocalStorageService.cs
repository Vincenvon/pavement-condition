using System.Threading.Tasks;

namespace PavementCondition.UI.Services.LocalStorage
{
    public interface ILocalStorageService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
        Task RemoveAsync(string key);
    }
}
