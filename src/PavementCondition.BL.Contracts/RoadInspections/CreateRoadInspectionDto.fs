namespace PavementCondition.BL.Contracts.RoadInspections

open System

type CreateRoadInspectionDto = {
    RoadId: int
    Number: string
    Engineer: string
    InspectionDate: DateTime
}