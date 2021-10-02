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