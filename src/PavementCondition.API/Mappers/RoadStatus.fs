module PavementCondition.API.Mappers.RoadStatus

open PavementCondition.BL.Contracts.RoadStatus
open PavementCondition.API.Contracts.RoadStatus

let mapDtoToReponse (dto: RoadStatusTableDto): RoadStatusTableResponse = 
    {
        RoadId = dto.RoadId
        RoadNumber = dto.RoadNumber
        LastInspectionId = dto.LastInspectionId
        LastInspectionNumber = dto.LastInspectionNumber
        LastInspectionDate = dto.LastInspectionDate
        DefectPercent = dto.DefectPercent
    }