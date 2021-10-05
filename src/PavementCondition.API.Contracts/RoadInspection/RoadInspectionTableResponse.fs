namespace PavementCondition.API.Contracts.RoadInspection

open System

type RoadInspectionTableResponse = {
    Id: int
    RoadId: int
    RoadNumber: string
    Number: string
    Engineer: int
    InspectionDate: DateTime
}

