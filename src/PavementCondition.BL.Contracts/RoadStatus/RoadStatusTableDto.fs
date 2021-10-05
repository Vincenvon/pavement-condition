namespace PavementCondition.BL.Contracts.RoadStatus

open System

type RoadStatusTableDto = {
    RoadId: int
    RoadNumber: string
    LastInspectionId: option<int>
    LastInspectionNumber: option<string>
    LastInspectionDate: option<DateTime>
    DefectPercent: option<decimal>
}