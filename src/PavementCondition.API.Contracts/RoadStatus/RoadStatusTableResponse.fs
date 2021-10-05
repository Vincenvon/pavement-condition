namespace PavementCondition.API.Contracts.RoadStatus

open System


type RoadStatusTableResponse = {
    RoadId: int
    RoadNumber: string
    LastInspectionId: option<int>
    LastInspectionNumber: option<string>
    LastInspectionDate: option<DateTime>
    DefectPercent: option<decimal>
}