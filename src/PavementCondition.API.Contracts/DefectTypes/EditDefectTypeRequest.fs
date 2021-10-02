namespace PavementCondition.API.Contracts.DefectTypes

open System

type EditDefectTypeRequest = {
    Id: int
    Name: string
    CreatedDate: DateTime
}

