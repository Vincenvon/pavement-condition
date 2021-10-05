module PavementCondition.BL.Validators.RoadDefects

open PavementCondition.BL.Contracts
open PavementCondition.BL.Contracts.RoadDefects
open PavementCondition.DataAccess

let validateCreateDto (db: DatabaseContext) (dto: CreateRoadDefectDto): ValidationResult = 
    {
        Success = true
        Message = ""
    }

let validateId (db: DatabaseContext) (id: int): ValidationResult = 
    let idExisting = 
        query {
            for roadDefect in db.RoadDefects do
            exists (roadDefect.Id = id)
        }
    match idExisting with
    |true -> { 
        Success = true 
        Message = "" }
    |false -> {
        Success = false
        Message = "Road inspection id doesn't exist"
    }

let validateEditDto (db: DatabaseContext) (dto: RoadDefectDto): ValidationResult = 
    {
        Success = true
        Message = ""
    }