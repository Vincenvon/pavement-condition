namespace PavementCondition.Entity

open System

[<CLIMutable>]
type DefectType = {
    Id: int
    Name: string
    CreatedDate: DateTime
}