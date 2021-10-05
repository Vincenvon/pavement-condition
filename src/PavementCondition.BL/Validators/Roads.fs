module PavementCondition.BL.Validators.Roads

open PavementCondition.BL.Contracts.Roads
open PavementCondition.DataAccess
open PavementCondition.BL.Contracts

let validateCreateDto (db: DatabaseContext) (dto: CreateRoadDto): ValidationResult = 
    let numberExisting = 
        query {
            for road in db.Roads do
            exists (road.Number = dto.Number)
        }
    match numberExisting with
    |true -> { 
        Success = false 
        Message = "Road number already exists" }
    |false -> {
        Success = true
        Message = ""
    }

let validateRoadId (db: DatabaseContext) (roadId: int): ValidationResult = 
    let idExisting = 
        query {
            for road in db.Roads do
            exists (road.Id = roadId)
        }
    match idExisting with
    |true -> { 
        Success = true 
        Message = "" }
    |false -> {
        Success = false
        Message = "Road id doesn't exist"
    }

let validateEditRoadDto (db: DatabaseContext) (dto: RoadDto): ValidationResult = 
    let idValidationResult = validateRoadId db dto.Id

    match idValidationResult.Success with
    | false -> idValidationResult
    | true -> 
        let numberExisting = 
            query {
                for road in db.Roads do
                exists (road.Number = dto.Number && road.Id <> dto.Id)
            }
        match numberExisting with
        |true -> { 
            Success = false 
            Message = "Road number already exists" }
        |false -> {
            Success = true
            Message = ""
        }

