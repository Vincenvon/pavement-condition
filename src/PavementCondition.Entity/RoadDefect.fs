namespace PavementCondition.Entity

[<CLIMutable>]
type RoadDefect = {
      Id: int
      mutable RoadInspectionId: int
      mutable DefectTypeId: int
      mutable DefectStartPoint: decimal
      mutable DefectDistance: decimal
};

