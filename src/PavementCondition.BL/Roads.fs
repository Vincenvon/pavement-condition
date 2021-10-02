module PavementCondition.BL.Roads

open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.Roads
open PavementCondition.BL.Mappers.Roads
open PavementCondition.BL.Validators.Roads
open System

let get (db: DatabaseContext): RoadDto[] = 
    query {
        for road in db.Roads do
        select road
    } |> Seq.toArray |> Array.map mapEntityToRoadDto

let create (db: DatabaseContext) (dto: CreateRoadDto): RoadDto = 
    let validationResult = validateCreateDto db dto
    match validationResult.Success with
    |true -> 
        let entity = mapCreateDtoToEntity dto
        db.Roads.Add entity |> ignore
        db.SaveChanges() |> ignore
        mapEntityToRoadDto entity
    |false ->
        raise(Exception(validationResult.Message))