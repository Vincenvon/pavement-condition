namespace PavementCondition.API

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open PavementCondition.DataAccess
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open NSwag.Generation.Processors.Security
open NSwag

type Startup private() as self =
    new (environment: IWebHostEnvironment) as this =
        let builder = new ConfigurationBuilder()
        builder.SetBasePath(environment.ContentRootPath) |> ignore
        builder.AddJsonFile("appsettings.json", true, true)|> ignore
        builder.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)|> ignore

        builder.AddEnvironmentVariables() |> ignore
        Startup() then
        this.Configuration <- builder.Build() :> IConfiguration

    member val Configuration : IConfiguration = null with get, set
    
    // This method gets called by the runtime. Use this method to add services to the container.
    member _.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddControllers() |> ignore
        services.AddAuthorization() |> ignore
        services.AddDbContext<DatabaseContext>(
            fun optionsBuilder ->
                optionsBuilder.UseNpgsql(
                    self.Configuration.GetConnectionString("DefaultConnection")
                ) |> ignore
            )  |> ignore

        services.AddSwaggerDocument(
            fun config -> 
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT token"))
                let schema = new OpenApiSecurityScheme()
                schema.Type <- OpenApiSecuritySchemeType.ApiKey
                schema.Name <- "Authorization"
                schema.Description <- "Copy 'Bearer ' + valid JWT token into field"
                schema.In <- OpenApiSecurityApiKeyLocation.Header
                config.AddSecurity("JWT token", schema) |> ignore
        ) |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore
        app.UseHttpsRedirection()
           .UseSwaggerUi3()
           .UseRouting()
           .UseAuthorization()
           .UseEndpoints(fun endpoints ->
                endpoints.MapControllers() |> ignore
            ) |> ignore