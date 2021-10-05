namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PavementCondition.DataAccess
open PavementCondition.BL.RoadStatus
open PavementCondition.API.Mappers.RoadStatus


[<ApiController>]
[<Route("[controller]")>]
type RoadStatusesController (logger : ILogger<RoadStatusesController>, ctx : DatabaseContext) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() = 
        get ctx |> Array.map mapDtoToReponse
