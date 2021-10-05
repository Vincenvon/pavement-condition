namespace PavementCondition.Entity

open System

[<CLIMutable>]
type RoadInspection = {
    Id: int
    mutable RoadId: int
    mutable Number: string
    mutable Engineer: int
    mutable InspectionDate: DateTime
}