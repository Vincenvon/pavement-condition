namespace PavementCondition.BL.Contracts.RoadInspections

open System

type RoadInspectionDto = {
    Id: int
    RoadId: int
    Number: string
    Engineer: int
    InspectionDate: DateTime
}