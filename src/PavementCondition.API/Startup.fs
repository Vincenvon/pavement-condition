namespace PavementCondition.API

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open PavementCondition.DataAccess
open Microsoft.EntityFrameworkCore

type Startup(configuration: IConfiguration) =
    member _.Configuration = configuration

    // This method gets called by the runtime. Use this method to add services to the container.
    member _.ConfigureServices(services: IServiceCollection) =
        // Add framework services.
        services.AddAuthorization() |> ignore
        services.AddControllers() |> ignore
        services.AddDbContext<DatabaseContext>(
            fun optionsBuilder ->
                optionsBuilder.UseNpgsql(
                   configuration.GetConnectionString("DefaultConnection")
                ) |> ignore
            )  |> ignore

        services.AddCors(fun o -> 
            o.AddPolicy("DefaulCors", fun builder -> 
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader() |> ignore
            )
        ) |> ignore

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if (env.IsDevelopment()) then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseCors("DefaulCors") |> ignore
        app.UseAuthentication()|> ignore
        app.UseHttpsRedirection() |> ignore
        app.UseRouting() |> ignore
        app.UseEndpoints(fun endpoints ->
                endpoints.MapControllers() |> ignore
            ) |> ignore
