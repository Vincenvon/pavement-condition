namespace PavementCondition.API.Contracts.RoadDefects

type EditRoadDefectRequest = {
    Id: int
    RoadInspectionId: int
    DefectTypeId: int
    DefectStartPoint: decimal
    DefectDistance: decimal
}