namespace PavementCondition.API.Contracts.DefectTypes

open System

[<CLIMutable>]
type DefectTypeResponse = {
    Id: int
    Name: string
    CreatedDate: DateTime
}

