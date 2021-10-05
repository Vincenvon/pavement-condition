module PavementCondition.BL.RoadStatus

open PavementCondition.DataAccess
open PavementCondition.BL.Contracts.RoadStatus
open System.Linq


let get (db: DatabaseContext): RoadStatusTableDto[] = 
    let roads = 
        query {
            for road in db.Roads do
            select road
        }|> Seq.toArray

    let inspections =
        query {
            for inspection in db.RoadInspections do
            select inspection
        }|> Seq.toArray

    let roadDefects = 
        query {
            for roadDefect in db.RoadDefects do
            select roadDefect
        }|> Seq.toArray

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
            }

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
        }

    query {
        for road in roads do 
        leftOuterJoin inspection in lastInspections on (road.Id = inspection.RoadId) into joinedInspections
        for joinedInspection in joinedInspections.DefaultIfEmpty() do
        leftOuterJoin roadDefect in roadDefectsByInspection on (joinedInspection.LastInspection.Id = roadDefect.RoadInspectionId) into jonedRoadDefects
        for jonedRoadDefect in jonedRoadDefects.DefaultIfEmpty() do
        select {
                RoadId = road.Id; 
                RoadNumber = road.Number;
                LastInspectionId = Some(joinedInspection.LastInspection.Id)
                LastInspectionNumber = Some(joinedInspection.LastInspection.Number)
                LastInspectionDate = Some(joinedInspection.LastInspection.InspectionDate)
                DefectPercent = Some(road.Distance / jonedRoadDefect.DefectSumDistance)
            }
    }|> Seq.toArray
