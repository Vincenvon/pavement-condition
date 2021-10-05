namespace PavementCondition.API.Contracts.RoadDefects

type CreateRoadDefectRequest = {
    RoadInspectionId: int
    DefectTypeId: int
    DefectStartPoint: decimal
    DefectDistance: decimal
}