namespace PavementCondition.API.Contracts.RoadInspection

open System

type RoadInspectionReponse = {
    Id: int
    RoadId: int
    Number: string
    Engineer: string
    InspectionDate: DateTime
}

