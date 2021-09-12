using PavementCondition.UI.Models.Account;

using System.Threading.Tasks;

namespace PavementCondition.UI.Services.Account
{
    public class AccountService : IAccountService
    {
        public Task<string> GetTokenAsync()
        {
            return Task.FromResult((string)null);
        }

        public Task LoginAsync(LoginModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task RegisterAsync(RegisterModel registerModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
