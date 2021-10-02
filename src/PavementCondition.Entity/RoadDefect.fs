namespace PavementCondition.Entity

[<CLIMutable>]
type RoadDefect = {
      Id: int
      DefectTypeId: int
      DefectStartPoint: decimal
      DefectDistance: decimal
};

