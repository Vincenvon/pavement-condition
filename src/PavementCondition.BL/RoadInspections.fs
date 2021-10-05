module PavementCondition.BL.RoadInspections

open PavementCondition.BL.Validators.RoadInspections
open PavementCondition.BL.Mappers.RoadInspections
open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.RoadInspections
open System
open System.Linq


let get (db: DatabaseContext): RoadInspectionTableDto[] = 
    query {
        for roadInspection in db.RoadInspections do
        leftOuterJoin road in db.Roads on (roadInspection.RoadId = road.Id) into joinedRoads
        for joinedRoad in joinedRoads.DefaultIfEmpty() do
        select {| 
                Id = roadInspection.Id; 
                RoadId = roadInspection.RoadId; 
                RoadNumber = joinedRoad.Number; 
                Number = roadInspection.Number; 
                Engineer = roadInspection.Engineer; 
                InspectionDate = roadInspection.InspectionDate 
        |}
    } |> Seq.toArray |> Array.map(fun db -> 
            {
                Id = db.Id
                RoadId = db.RoadId
                RoadNumber = db.RoadNumber
                Number = db.Number
                Engineer = db.Engineer
                InspectionDate = db.InspectionDate
            }
        )
        

let create (db: DatabaseContext) (dto: CreateRoadInspectionDto): RoadInspectionDto = 
    let validationResult = validateCreateDto db dto
    match validationResult.Success with
    |true -> 
        let entity = mapCreateDtoToEntity dto
        db.RoadInspections.Add entity |> ignore
        db.SaveChanges() |> ignore
        mapEntityToRoadDto entity
    |false ->
        raise(Exception(validationResult.Message))

let getById (db: DatabaseContext) (roadId: int): RoadInspectionDto = 
    let validationResult = validateId db roadId
    match validationResult.Success with
    |true -> 
        query {
            for road in db.RoadInspections do
            find (road.Id = roadId)
        } |>  mapEntityToRoadDto
    |false ->
        raise(Exception(validationResult.Message))

let edit (db: DatabaseContext) (roadDto: RoadInspectionDto): RoadInspectionDto = 
    let validationResult = validateEditDto db roadDto
    match validationResult.Success with
    |true -> 
        let entity = 
            query {
                for road in db.RoadInspections do
                find (road.Id = roadDto.Id)
            } 
        db.RoadInspections.Update (mutateEntityByDto entity roadDto) |> ignore
        db.SaveChanges() |> ignore
        mapEntityToRoadDto entity
    |false ->
        raise(Exception(validationResult.Message))

let delete (db: DatabaseContext) (roadId: int) = 
    let validationResult = validateId db roadId
    match validationResult.Success with
    | true -> 
        let entity = 
            query {
                for road in db.RoadInspections do
                find (road.Id = roadId)
            }  
    
        db.RoadInspections.Remove entity |> ignore
        db.SaveChanges() |> ignore
    | false -> 
        raise(Exception(validationResult.Message))