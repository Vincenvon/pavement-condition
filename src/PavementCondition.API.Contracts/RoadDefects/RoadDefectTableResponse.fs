namespace PavementCondition.API.Contracts.RoadDefects

type RoadDefectTableResponse = {
    Id: int
    RoadInspectionId: int
    RoadInspectionNumber: string
    DefectTypeId: int
    DefectTypeName: string
    DefectStartPoint: decimal
    DefectDistance: decimal
}