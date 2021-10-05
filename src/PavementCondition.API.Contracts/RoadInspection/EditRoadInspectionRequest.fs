﻿namespace PavementCondition.API.Contracts.RoadInspection

open System

type EditRoadInspectionRequest = {
    Id: int
    RoadId: int
    Number: string
    Engineer: int
    InspectionDate: DateTime
}

