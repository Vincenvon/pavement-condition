module PavementCondition.BL.Validators.RoadInspections

open PavementCondition.DataAccess
open PavementCondition.BL.Contracts
open PavementCondition.BL.Contracts.RoadInspections

let validateCreateDto (db: DatabaseContext) (dto: CreateRoadInspectionDto): ValidationResult = 
    let numberExisting = 
        query {
            for road in db.RoadInspections do
            exists (road.Number = dto.Number)
        }
    match numberExisting with
    |true -> { 
        Success = false 
        Message = "Road inspection number already exists" }
    |false -> {
        Success = true
        Message = ""
    }

let validateId (db: DatabaseContext) (id: int): ValidationResult = 
    let idExisting = 
        query {
            for road in db.RoadInspections do
            exists (road.Id = id)
        }
    match idExisting with
    |true -> { 
        Success = true 
        Message = "" }
    |false -> {
        Success = false
        Message = "Road inspection id doesn't exist"
    }

let validateEditDto (db: DatabaseContext) (dto: RoadInspectionDto): ValidationResult = 
    let idValidationResult = validateId db dto.Id

    match idValidationResult.Success with
    | false -> idValidationResult
    | true -> 
        let numberExisting = 
            query {
                for road in db.Roads do
                exists (road.Number = dto.Number)
            }
        match numberExisting with
        |true -> { 
            Success = false 
            Message = "Road inspection number already exists" }
        |false -> {
            Success = true
            Message = ""
        }