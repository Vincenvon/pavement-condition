module PavementCondition.API.Mappers.Roads

open PavementCondition.BL.Contracts.Roads
open PavementCondition.API.Contracts.Roads

let mapRoadDtoToRoadResponse (dto: RoadDto): RoadResponse = 
    let response:RoadResponse  = {
        Id = dto.Id
        Number = dto.Number
        StartPoint = dto.StartPoint
        EndPoint = dto.EndPoint
        Distance = dto.Distance
        ServiceOrganization = dto.ServiceOrganization
    }
    response

let mapCreateRequestToCreateDto (request: CreateRoadRequest): CreateRoadDto = 
    let dto: CreateRoadDto = {
        Number = request.Number
        StartPoint = request.StartPoint
        EndPoint = request.EndPoint
        Distance = request.Distance
        ServiceOrganization = request.ServiceOrganization
    }
    dto