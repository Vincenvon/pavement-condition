namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PavementCondition.DataAccess
open PavementCondition.BL.RoadInspections
open PavementCondition.API.Contracts.RoadInspection
open PavementCondition.API.Mappers.RoadInspections


[<ApiController>]
[<Route("[controller]")>]
type RoadInspectionsController (logger : ILogger<RoadInspectionsController>, ctx : DatabaseContext) =
    inherit ControllerBase()

    [<HttpGet>]
    member _.Get() = 
        get ctx |> Array.map mapRoadInspectionTableDtoToRoadInspectionTableResponse

    [<HttpPost>]
    member _.Create([<FromBody>]model: CreateRoadInspectionRequest) =
        let createdDto = create ctx (mapCreateRequestToCreateDto model)
        mapRoadInspectionDtoToRoadInspectionResponse createdDto

    [<HttpGet("{roadId:int}")>]
    member _.GetById(roadId: int) = 
        getById ctx roadId |> mapRoadInspectionDtoToRoadInspectionResponse

    [<HttpPut>]
    member _.Edit([<FromBody>]model: EditRoadInspectionRequest) = 
        edit ctx (mapEditRequestToDto model) |> mapRoadInspectionDtoToRoadInspectionResponse

    [<HttpDelete("{roadId:int}")>]
    member _.Delete(roadId: int) = 
        delete ctx roadId |> ignore