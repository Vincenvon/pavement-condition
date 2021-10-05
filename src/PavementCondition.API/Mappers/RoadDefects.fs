module PavementCondition.API.Mappers.RoadDefects

open PavementCondition.BL.Contracts.RoadDefects
open PavementCondition.API.Contracts.RoadDefects

let mapRoadDefectTableDtoToRoadDefectTableResponse (dto: RoadDefectTableDto): RoadDefectTableResponse = 
    let response:RoadDefectTableResponse  = {
        Id = dto.Id
        RoadInspectionId = dto.RoadInspectionId
        RoadInspectionNumber = dto.RoadInspectionNumber
        DefectTypeId = dto.DefectTypeId
        DefectTypeName = dto.DefectTypeName
        DefectStartPoint = dto.DefectStartPoint
        DefectDistance = dto.DefectDistance
    }
    response

let mapRoadDefectDtoToRoadDefectResponse (dto: RoadDefectDto): RoadDefectResponse = 
    let response:RoadDefectResponse  = {
        Id = dto.Id
        RoadInspectionId = dto.RoadInspectionId
        DefectTypeId = dto.DefectTypeId
        DefectStartPoint = dto.DefectStartPoint
        DefectDistance = dto.DefectDistance
    }
    response

let mapCreateRequestToCreateDto (request: CreateRoadDefectRequest): CreateRoadDefectDto = 
    let dto: CreateRoadDefectDto = {
        RoadInspectionId = request.RoadInspectionId
        DefectTypeId = request.DefectTypeId
        DefectStartPoint = request.DefectStartPoint
        DefectDistance = request.DefectDistance
    }
    dto

let mapEditRequestToDto (reuqest: EditRoadDefectRequest): RoadDefectDto = 
    let dto: RoadDefectDto = {
        Id = reuqest.Id
        RoadInspectionId = reuqest.RoadInspectionId
        DefectTypeId = reuqest.DefectTypeId
        DefectStartPoint = reuqest.DefectStartPoint
        DefectDistance = reuqest.DefectDistance
    }
    dto