namespace PavementCondition.API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PavementCondition.DataAccess
open PavementCondition.API.Contracts.DefectTypes
open PavementCondition.BL.Contracts.DefectTypes
open PavementCondition.BL.DefectTypes

[<ApiController>]
[<Route("[controller]")>]
type DefectTypesController (logger : ILogger<DefectTypesController>, ctx : DatabaseContext) =
    inherit ControllerBase()

    [<HttpPost>]
    member _.Create([<FromBody>]model: CreateDefectTypeRequest) =
        let createDto: CreateDefectTypeDto = {
            Name = model.Name
        }
        let createdDto = create ctx createDto
        let createdResponse: DefectTypeResponse = {
            Id = createdDto.Id
            Name = createdDto.Name
            CreatedDate = createdDto.CreatedDate
        }
        createdResponse

    [<HttpGet>]
    member _.Get() = 
        get ctx |> Array.map(fun (x: DefectTypeDto) -> 
            let rsp: DefectTypeResponse = {
                Id = x.Id
                Name = x.Name
                CreatedDate = x.CreatedDate
            }
            rsp)
            