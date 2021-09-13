namespace PavementCondition.API.Controllers

open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.Mvc
open PavementCondition.API.Contracts.Accounts
open PavementCondition.BL.Accounts
open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.Accounts

[<ApiController>]
[<Route("[controller]")>]
type AccountsController (logger : ILogger<AccountsController> , ctx : DatabaseContext) =
    inherit Controller()

    [<HttpPost>]
    member _.Create([<FromBody>]model: CreateRequest) = 
        let createDto: CreateDto = {
            Email = model.Email
            FirstName = model.FirstName
            LastName = model.LastName
            Username = model.Username
            Password = model.Password
        }
        let createdDto = create ctx createDto
        createdDto
