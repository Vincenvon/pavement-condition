namespace PavementCondition.BL.Contracts.RoadInspections

open System

type RoadInspectionTableDto = {
    Id: int
    RoadId: int
    RoadNumber: string
    Number: string
    Engineer: int
    InspectionDate: DateTime
}