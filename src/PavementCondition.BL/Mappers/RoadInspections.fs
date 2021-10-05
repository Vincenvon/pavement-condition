module PavementCondition.BL.Mappers.RoadInspections

open PavementCondition.Entity
open PavementCondition.BL.Contracts.RoadInspections

let mapEntityToRoadDto (entity: RoadInspection): RoadInspectionDto =
    let dto: RoadInspectionDto = {
        Id = entity.Id
        RoadId = entity.RoadId
        Number = entity.Number
        Engineer = entity.Engineer
        InspectionDate = entity.InspectionDate
    }
    dto

let mapCreateDtoToEntity(dto: CreateRoadInspectionDto): RoadInspection = 
    let entity: RoadInspection = {
        Id = 0
        RoadId = dto.RoadId
        Number = dto.Number
        Engineer = dto.Engineer
        InspectionDate = dto.InspectionDate
    }
    entity

let mutateEntityByDto (entity: RoadInspection) (dto: RoadInspectionDto) : RoadInspection = 
    entity.RoadId <- dto.RoadId
    entity.Number <- dto.Number
    entity.Engineer <- dto.Engineer
    entity.InspectionDate <- dto.InspectionDate
    entity