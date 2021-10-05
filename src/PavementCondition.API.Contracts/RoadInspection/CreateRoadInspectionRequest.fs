namespace PavementCondition.API.Contracts.RoadInspection

open System

type CreateRoadInspectionRequest = {
    RoadId: int
    Number: string
    Engineer: int
    InspectionDate: DateTime
}

