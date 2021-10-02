using PavementCondition.API.Contracts.Accounts;
using PavementCondition.UI.Constants;
using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Models.Account;
using PavementCondition.UI.Services.LocalStorage;

using System.Threading.Tasks;

namespace PavementCondition.UI.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IApiClient _apiClient;
        private readonly ILocalStorageService _localStorageService;

        public AccountService(IApiClient apiClient, ILocalStorageService localStorageService)
        {
            _apiClient = apiClient;
            _localStorageService = localStorageService;
        }

        public Task<string> GetTokenAsync()
        {
            return _localStorageService.GetAsync<string>(LocalStorageKeyConstants.TokenKey);
        }

        public async Task LoginAsync(LoginModel model)
        {
            var response = await _apiClient.PostAsync<LoginRequest, LoginResponse>(new LoginRequest(model.Email, model.Password), "/accounts/login");
            await _localStorageService.SetAsync(LocalStorageKeyConstants.TokenKey, response.Token);
        }

        public async Task RegisterAsync(RegisterModel registerModel)
        {
            var response = await _apiClient.PostAsync<RegisterRequest, RegisterResponse>(
                new RegisterRequest(
                    registerModel.Email,
                    registerModel.FirstName,
                    registerModel.LastName,
                    registerModel.Username,
                    registerModel.Password), "/accounts");
        }
    }
}
