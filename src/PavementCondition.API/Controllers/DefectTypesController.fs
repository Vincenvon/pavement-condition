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
        let createdResponse: CreateDefectTypeResponse = {
            Id = createdDto.Id
            Name = createdDto.Name
            CreatedDate = createdDto.CreatedDate
        }
        createdResponse