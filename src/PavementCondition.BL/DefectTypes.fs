module PavementCondition.BL.DefectTypes

open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.DefectTypes
open PavementCondition.Entity
open System

let create (db: DatabaseContext) (dto: CreateDefectTypeDto ) : DefectTypeDto = 
    let dbDefectTypeExisits = 
        query {
            for defectType in db.DefectTypes do
            exists (defectType.Name = dto.Name)
        }
    match dbDefectTypeExisits with
        | false -> 
            let newDefectType: DefectType = {
                Id = 0
                Name = dto.Name
                CreatedDate = DateTime.Now
            }
            db.DefectTypes.Add newDefectType |> ignore
            db.SaveChanges() |> ignore
            let createdDto: DefectTypeDto = {
                Id = newDefectType.Id
                Name = newDefectType.Name
                CreatedDate = newDefectType.CreatedDate
            }
            createdDto
        | true -> 
            let dbDefectType = 
                query {
                    for defectType in db.DefectTypes do
                    find (defectType.Name = dto.Name)
                }
            let createdDto: DefectTypeDto = {
                Id = dbDefectType.Id
                Name = dbDefectType.Name
                CreatedDate = dbDefectType.CreatedDate
            }
            createdDto
        