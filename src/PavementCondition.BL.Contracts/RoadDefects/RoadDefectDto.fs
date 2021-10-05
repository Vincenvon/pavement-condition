namespace PavementCondition.BL.Contracts.RoadDefects

type RoadDefectDto = {
    Id: int
    RoadInspectionId: int
    DefectTypeId: int
    DefectStartPoint: decimal
    DefectDistance: decimal
}