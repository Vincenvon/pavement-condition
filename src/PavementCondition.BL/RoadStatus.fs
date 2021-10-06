module PavementCondition.BL.RoadStatus

open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.RoadStatus
open System.Linq


let get (db: DatabaseContext): RoadStatusTableDto[] = 
    let roads = 
        query {
            for road in db.Roads do
            select road
        }|> Seq.toList

    let inspections =
        query {
            for inspection in db.RoadInspections do
            select inspection
        }|> Seq.toList

    let roadDefects = 
        query {
            for roadDefect in db.RoadDefects do
            select roadDefect
        }|> Seq.toList


    roads |> Seq.map (fun r -> 
        let lastInspection =  inspections|> Seq.where (fun i -> (i.RoadId=r.Id)) |> Seq.sortByDescending (fun i -> i.InspectionDate) |> Seq.tryHead
        match lastInspection.IsNone with
        |true -> {
                RoadId = r.Id; 
                RoadNumber = r.Number;
                LastInspectionId = None 
                LastInspectionNumber = None
                LastInspectionDate = None
                DefectPercent = None
            }
        |false-> 
            let inspectionDefectsSum = roadDefects |> Seq.where(fun rd -> (rd.RoadInspectionId = lastInspection.Value.Id)) |> Seq.sumBy (fun rd -> rd.DefectDistance)
            {
                RoadId = r.Id; 
                RoadNumber = r.Number;
                LastInspectionId = Some(lastInspection.Value.Id)
                LastInspectionNumber = Some(lastInspection.Value.Number)
                LastInspectionDate = Some(lastInspection.Value.InspectionDate)
                DefectPercent =
                match inspectionDefectsSum with
                        | ids when ids > 0M -> Some(r.Distance/inspectionDefectsSum)
                        |_ -> Some(0M)
            }
        ) |> Seq.toArray