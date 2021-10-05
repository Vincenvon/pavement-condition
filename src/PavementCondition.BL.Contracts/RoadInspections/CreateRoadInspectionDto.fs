namespace PavementCondition.BL.Contracts.RoadInspections

open System

type CreateRoadInspectionDto = {
    RoadId: int
    Number: string
    Engineer: int
    InspectionDate: DateTime
}