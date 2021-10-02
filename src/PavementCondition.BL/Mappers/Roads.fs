module PavementCondition.BL.Mappers.Roads

open PavementCondition.Entity
open PavementCondition.BL.Contracts.Roads

let mapEntityToRoadDto (entity: Road): RoadDto =
    let dto: RoadDto = {
        Id = entity.Id
        Number = entity.Number
        StartPoint = entity.StartPoint
        EndPoint = entity.EndPoint
        Distance = entity.Distance
        ServiceOrganization = entity.ServiceOrganization
    }
    dto

let mapCreateDtoToEntity(dto: CreateRoadDto): Road = 
    let entity: Road = {
        Id = 0
        Number = dto.Number
        StartPoint = dto.StartPoint
        EndPoint = dto.EndPoint
        Distance = dto.Distance
        ServiceOrganization = dto.ServiceOrganization
    }
    entity

