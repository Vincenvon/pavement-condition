namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PavementCondition.DataAccess
open PavementCondition.BL.Roads
open PavementCondition.API.Mappers.Roads
open PavementCondition.API.Contracts.Roads


[<ApiController>]
[<Route("[controller]")>]
type RoadsController (logger : ILogger<RoadsController>, ctx : DatabaseContext) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() = 
        get ctx |> Array.map mapRoadDtoToRoadResponse

    [<HttpPost>]
    member _.Create([<FromBody>]model: CreateRoadRequest) =
        let createdDto = create ctx (mapCreateRequestToCreateDto model)
        mapRoadDtoToRoadResponse createdDto

    [<HttpGet("{roadId:int}")>]
    member _.GetById(roadId: int) = 
        getById ctx roadId |> mapRoadDtoToRoadResponse

    [<HttpPut>]
    member _.Edit([<FromBody>]model: EditRoadRequest) = 
        edit ctx (mapEditRequestToDto model) |> mapRoadDtoToRoadResponse

    [<HttpDelete("{roadId:int}")>]
    member _.Delete(roadId: int) = 
        delete ctx roadId |> ignore