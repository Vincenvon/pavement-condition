namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PavementCondition.API.Contracts.Accounts
open PavementCondition.BL.Accounts
open PavementCondition.BL.Contracts.Accounts
open PavementCondition.DataAccess

[<ApiController>]
[<Route("[controller]")>]
type AccountsController (logger : ILogger<AccountsController>, ctx : DatabaseContext) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Register([<FromBody>]model: RegisterRequest) =
        let createDto: CreateDto = {
            Email = model.Email
            FirstName = model.FirstName
            LastName = model.LastName
            Username = model.Username
            Password = model.Password
        }
        let createdDto = create ctx createDto
        createdDto