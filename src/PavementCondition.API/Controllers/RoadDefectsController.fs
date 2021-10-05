namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PavementCondition.DataAccess
open PavementCondition.BL.RoadDefects
open PavementCondition.API.Contracts.RoadDefects
open PavementCondition.API.Mappers.RoadDefects


[<ApiController>]
[<Route("[controller]")>]
type RoadDefectsController (logger : ILogger<RoadDefectsController>, ctx : DatabaseContext) =
    inherit ControllerBase()

    [<HttpGet("inspections/{roadInspectionId:int}")>]
    member _.Get(roadInspectionId:int) = 
        get ctx roadInspectionId |> Array.map mapRoadDefectTableDtoToRoadDefectTableResponse

    [<HttpPost>]
    member _.Create([<FromBody>]model: CreateRoadDefectRequest) =
        let createdDto = create ctx (mapCreateRequestToCreateDto model)
        mapRoadDefectDtoToRoadDefectResponse createdDto

    [<HttpGet("{roadId:int}")>]
    member _.GetById(roadId: int) = 
        getById ctx roadId |> mapRoadDefectDtoToRoadDefectResponse

    [<HttpPut>]
    member _.Edit([<FromBody>]model: EditRoadDefectRequest) = 
        edit ctx (mapEditRequestToDto model) |> mapRoadDefectDtoToRoadDefectResponse

    [<HttpDelete("{roadId:int}")>]
    member _.Delete(roadId: int) = 
        delete ctx roadId |> ignore