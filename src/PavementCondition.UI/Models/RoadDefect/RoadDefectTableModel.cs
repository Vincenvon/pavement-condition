namespace PavementCondition.UI.Models.RoadDefect
{
    public class RoadDefectTableModel
    {
        public int Id { get; set; }

        public int RoadInspectionId { get; set; }

        public string RoadInspectionNumber { get; set; }

        public int DefectTypeId { get; set; }

        public string DefectTypeName { get; set; }

        public decimal DefectStartPoint { get; set; }

        public decimal DefectDistance { get; set; }
    }
}