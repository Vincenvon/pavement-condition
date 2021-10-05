namespace PavementCondition.API.Contracts.RoadDefects

type RoadDefectResponse = {
    Id: int
    RoadInspectionId: int
    DefectTypeId: int
    DefectStartPoint: decimal
    DefectDistance: decimal
}