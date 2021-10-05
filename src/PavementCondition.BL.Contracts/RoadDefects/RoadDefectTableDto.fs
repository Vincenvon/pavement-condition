namespace PavementCondition.BL.Contracts.RoadDefects

type RoadDefectTableDto = {
    Id: int
    RoadInspectionId: int
    RoadInspectionNumber: string
    DefectTypeId: int
    DefectTypeName: string
    DefectStartPoint: decimal
    DefectDistance: decimal
}