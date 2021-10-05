module PavementCondition.API.Mappers.RoadInspections

open PavementCondition.BL.Contracts.RoadInspections
open PavementCondition.API.Contracts.RoadInspection

let mapRoadInspectionTableDtoToRoadInspectionTableResponse (dto: RoadInspectionTableDto): RoadInspectionTableResponse = 
    let response:RoadInspectionTableResponse  = {
        Id = dto.Id
        RoadNumber = dto.RoadNumber
        RoadId = dto.RoadId
        Number = dto.Number
        Engineer = dto.Engineer
        InspectionDate = dto.InspectionDate
    }
    response

let mapRoadInspectionDtoToRoadInspectionResponse (dto: RoadInspectionDto): RoadInspectionReponse = 
    let response:RoadInspectionReponse  = {
        Id = dto.Id
        RoadId = dto.RoadId
        Number = dto.Number
        Engineer = dto.Engineer
        InspectionDate = dto.InspectionDate
    }
    response

let mapCreateRequestToCreateDto (request: CreateRoadInspectionRequest): CreateRoadInspectionDto = 
    let dto: CreateRoadInspectionDto = {
        RoadId = request.RoadId
        Number = request.Number
        Engineer = request.Engineer
        InspectionDate = request.InspectionDate
    }
    dto

let mapEditRequestToDto (reuqest: EditRoadInspectionRequest): RoadInspectionDto = 
    let dto: RoadInspectionDto = {
        Id = reuqest.Id
        RoadId = reuqest.RoadId
        Number = reuqest.Number
        Engineer = reuqest.Engineer
        InspectionDate = reuqest.InspectionDate
    }
    dto