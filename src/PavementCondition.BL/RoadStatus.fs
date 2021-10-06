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

    let lastInspections = 
        query { 
            for inspection in inspections do
            groupBy inspection.RoadId into groupedInspections
            select {|
                        RoadId = groupedInspections.Key
                        LastInspection = query {
                                for groupedInspection in groupedInspections do
                                sortBy groupedInspection.InspectionDate
                                lastOrDefault
                                }
                    |}
            } |> Seq.toList

    let roadDefectsByInspection = 
        query {
            for roadDefect in roadDefects do
            groupBy roadDefect.RoadInspectionId into groupedRoadDefects
            select {|
                    RoadInspectionId = groupedRoadDefects.Key
                    DefectSumDistance = query {
                        for groupedRoadDefect in groupedRoadDefects do
                        sumBy groupedRoadDefect.DefectDistance
                }
                
            |}
        } |> Seq.toList

    query {
        for road in roads do 
        leftOuterJoin inspection in lastInspections on (road.Id = inspection.RoadId) into joinedInspections
        for inspection in joinedInspections do
        leftOuterJoin roadDefect in roadDefectsByInspection on (inspection.LastInspection.Id = roadDefect.RoadInspectionId) into jonedRoadDefects
        for roadDefect in jonedRoadDefects do
        select (road, inspection, roadDefect)
    }|> Seq.map (fun (road, inspection, roadDefect) -> 
                        {
                            RoadId = road.Id; 
                            RoadNumber = road.Number;
                            LastInspectionId = Some(inspection.LastInspection.Id)
                            LastInspectionNumber = Some(inspection.LastInspection.Number)
                            LastInspectionDate = Some(inspection.LastInspection.InspectionDate)
                            DefectPercent = Some(road.Distance / roadDefect.DefectSumDistance)
                        }
    ) |> Seq.toArray