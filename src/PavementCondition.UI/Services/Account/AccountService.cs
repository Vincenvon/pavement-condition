using PavementCondition.API.Contracts.Accounts;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.Account;

using System.Threading.Tasks;

namespace PavementCondition.UI.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IApiClient _apiClient;

        public AccountService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<string> GetTokenAsync()
        {
            return Task.FromResult((string)null);
        }

        public Task LoginAsync(LoginModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task RegisterAsync(RegisterModel registerModel)
        {
            await _apiClient.PostAsync<RegisterRequest, RegisterResponse>(
                new RegisterRequest(
                    registerModel.Email,
                    registerModel.FirstName,
                    registerModel.LastName,
                    registerModel.Username,
                    registerModel.Password));
        }
    }
}
