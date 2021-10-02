namespace PavementCondition.Entity

open System

[<CLIMutable>]
type DefectType = {
    Id: int
    mutable Name: string
    CreatedDate: DateTime
}