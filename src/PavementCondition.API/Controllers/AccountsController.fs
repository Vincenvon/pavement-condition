namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Routing
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore.Mvc
open PavementCondition.API.Contracts.Accounts

[<ApiController>]
[<Route("[controller]")>]
type AccountsController (logger : ILogger<AccountsController>) =
    inherit Controller()

    [<HttpPost>]
    member _.Create([<FromBody>]model: CreateRequest) = 
        let guid = Guid.NewGuid()
        let defects: DefectType[] = [| { Id = guid; Name = "Crack" } |]
        defects

