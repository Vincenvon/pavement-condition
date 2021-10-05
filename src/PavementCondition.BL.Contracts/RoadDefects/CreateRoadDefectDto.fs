namespace PavementCondition.BL.Contracts.RoadDefects

type CreateRoadDefectDto = {
    RoadInspectionId: int
    DefectTypeId: int
    DefectStartPoint: decimal
    DefectDistance: decimal
}