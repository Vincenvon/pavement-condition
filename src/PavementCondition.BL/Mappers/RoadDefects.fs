module PavementCondition.BL.Mappers.RoadDefects

open PavementCondition.Entity
open PavementCondition.BL.Contracts.RoadDefects

let mapEntityToRoadDto (entity: RoadDefect): RoadDefectDto =
    let dto: RoadDefectDto = {
        Id = entity.Id
        RoadInspectionId = entity.RoadInspectionId
        DefectTypeId = entity.DefectTypeId
        DefectStartPoint = entity.DefectStartPoint
        DefectDistance= entity.DefectDistance
    }
    dto

let mapCreateDtoToEntity(dto: CreateRoadDefectDto): RoadDefect = 
    let entity: RoadDefect = {
        Id = 0
        RoadInspectionId = dto.RoadInspectionId
        DefectTypeId = dto.DefectTypeId
        DefectStartPoint = dto.DefectStartPoint
        DefectDistance= dto.DefectDistance
    }
    entity

let mutateEntityByDto (entity: RoadDefect) (dto: RoadDefectDto) : RoadDefect = 
    entity.RoadInspectionId <- dto.RoadInspectionId
    entity.DefectTypeId <- dto.DefectTypeId
    entity.DefectStartPoint <- dto.DefectStartPoint
    entity.DefectDistance <- dto.DefectDistance
    entity