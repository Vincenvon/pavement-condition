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

let getById (db: DatabaseContext) (roadId: int): RoadDto = 
    let validationResult = validateRoadId db roadId
    match validationResult.Success with
    |true -> 
        query {
            for road in db.Roads do
            find (road.Id = roadId)
        } |>  mapEntityToRoadDto
    |false ->
        raise(Exception(validationResult.Message))

let edit (db: DatabaseContext) (roadDto: RoadDto): RoadDto = 
    let validationResult = validateEditRoadDto db roadDto
    match validationResult.Success with
    |true -> 
        let entity = 
            query {
                for road in db.Roads do
                find (road.Id = roadDto.Id)
            } 
        db.Roads.Update (mutateEntityByDto entity roadDto) |> ignore
        db.SaveChanges() |> ignore
        mapEntityToRoadDto entity
    |false ->
        raise(Exception(validationResult.Message))

let delete (db: DatabaseContext) (roadId: int) = 
    let validationResult = validateRoadId db roadId
    match validationResult.Success with
    | true -> 
        let entity = 
            query {
                for road in db.Roads do
                find (road.Id = roadId)
            }  
    
        db.Roads.Remove entity |> ignore
        db.SaveChanges() |> ignore
    | false -> 
        raise(Exception(validationResult.Message))