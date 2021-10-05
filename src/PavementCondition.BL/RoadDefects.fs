module PavementCondition.BL.RoadDefects

open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.RoadDefects
open PavementCondition.BL.Validators.RoadDefects
open PavementCondition.BL.Mappers.RoadDefects
open System

let get (db: DatabaseContext) (roadInspectionId: int): RoadDefectTableDto[] = 
    let roadDefects = 
        query {
            for roadDefect in db.RoadDefects do
            where (roadDefect.RoadInspectionId = roadInspectionId)
            select roadDefect
        } |> Seq.toArray
    
    let roadInspections = 
        query {
            for roadInspection in db.RoadInspections do
            where (roadInspection.Id = roadInspectionId)
            select roadInspection
        } |> Seq.toArray

    let defectTypes = 
        query {
            for defectType in db.DefectTypes do
            select defectType
        } |> Seq.toArray

    query {
        for roadDefect in roadDefects do
        join roadInspection in roadInspections on (roadDefect.RoadInspectionId = roadInspection.Id)
        join defectType in defectTypes on  (roadDefect.DefectTypeId = defectType.Id)
        where (roadDefect.RoadInspectionId = roadInspectionId)
        select {| 
                Id = roadDefect.Id
                RoadInspectionId = roadDefect.RoadInspectionId
                RoadInspectionNumber = roadInspection.Number
                DefectTypeId = defectType.Id
                DefectTypeName = defectType.Name
                DefectStartPoint = roadDefect.DefectStartPoint
                DefectDistance = roadDefect.DefectDistance
            |}
    } |> Seq.toArray |> Array.map(fun db -> 
            {
                Id = db.Id
                RoadInspectionId = db.RoadInspectionId
                RoadInspectionNumber = db.RoadInspectionNumber
                DefectTypeId = db.DefectTypeId
                DefectTypeName = db.DefectTypeName
                DefectStartPoint = db.DefectStartPoint
                DefectDistance = db.DefectDistance
            }
        )
        

let create (db: DatabaseContext) (dto: CreateRoadDefectDto): RoadDefectDto = 
    let validationResult = validateCreateDto db dto
    match validationResult.Success with
    |true -> 
        let entity = mapCreateDtoToEntity dto
        db.RoadDefects.Add entity |> ignore
        db.SaveChanges() |> ignore
        mapEntityToRoadDto entity
    |false ->
        raise(Exception(validationResult.Message))

let getById (db: DatabaseContext) (roadId: int): RoadDefectDto = 
    let validationResult = validateId db roadId
    match validationResult.Success with
    |true -> 
        query {
            for road in db.RoadDefects do
            find (road.Id = roadId)
        } |>  mapEntityToRoadDto
    |false ->
        raise(Exception(validationResult.Message))

let edit (db: DatabaseContext) (roadDto: RoadDefectDto): RoadDefectDto = 
    let validationResult = validateEditDto db roadDto
    match validationResult.Success with
    |true -> 
        let entity = 
            query {
                for road in db.RoadDefects do
                find (road.Id = roadDto.Id)
            } 
        db.RoadDefects.Update (mutateEntityByDto entity roadDto) |> ignore
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
                for road in db.RoadDefects do
                find (road.Id = roadId)
            }  
    
        db.RoadDefects.Remove entity |> ignore
        db.SaveChanges() |> ignore
    | false -> 
        raise(Exception(validationResult.Message))