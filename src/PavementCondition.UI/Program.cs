using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using PavementCondition.UI.Infrastructure;
using PavementCondition.UI.Services.Account;
using PavementCondition.UI.Services.Alert;
using PavementCondition.UI.Services.DefectType;
using PavementCondition.UI.Services.LocalStorage;
using PavementCondition.UI.Services.Road;
using PavementCondition.UI.Services.RoadDefect;
using PavementCondition.UI.Services.RoadInspection;
using PavementCondition.UI.Services.RoadStatus;

using Radzen;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PavementCondition.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var configuration = builder.Configuration;
            var apiHttpUrl = configuration["apiUrl"];
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddAutoMapper(typeof(Program).Assembly)
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IAlertService, AlertService>()
                .AddScoped<IApiClient, ApiClient>()
                .AddScoped<ILocalStorageService, LocalStorageService>()
                .AddScoped<IDefectTypeService, DefectTypeService>()
                .AddScoped<IRoadService, RoadService>()
                .AddScoped<IRoadInspectionService, RoadInspectionService>()
                .AddScoped<IRoadDefectService, RoadDefectService>()
                .AddScoped<IRoadStatusService, RoadStatusService>()
                .AddScoped<DialogService>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiHttpUrl) });

            await builder.Build().RunAsync();
        }
    }

}