namespace PavementCondition.Entity

open System

[<CLIMutable>]
type RoadInspection = {
    Id: int
    mutable RoadId: int
    mutable Number: string
    mutable Engineer: string
    mutable InspectionDate: DateTime
}