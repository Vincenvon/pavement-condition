using PavementCondition.UI.Models.Account;

using System.Threading.Tasks;

namespace PavementCondition.UI.Services.Account
{
    public interface IAccountService
    {
        Task<string> GetTokenAsync();
        
        Task LoginAsync(LoginModel model);

        Task RegisterAsync(RegisterModel registerModel);
    }
}
