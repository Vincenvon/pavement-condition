using System;

namespace PavementCondition.UI.Models.RoadStatus
{
    public class RoadStatusTableModel
    {
        public int RoadId { get; set; }

        public string RoadNumber { get; set; }

        public int? LastInspectionId { get; set; }

        public string LastInspectionNumber { get; set; }

        public DateTime? LastInspectionDate { get; set; }

        public decimal? DefectPercent { get; set; }
    }
}
