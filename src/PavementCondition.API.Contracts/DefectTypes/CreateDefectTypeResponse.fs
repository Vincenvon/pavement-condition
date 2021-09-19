namespace PavementCondition.API.Contracts.DefectTypes

open System

type CreateDefectTypeResponse = {
    Id: int
    Name: string
    CreatedDate: DateTime
}

