using System;

namespace PavementCondition.UI.Models.RoadInspection
{
    public class RoadInspectionTableModel
    {
        public int Id { get; set; }

        public int RoadId { get; set; }

        public string RoadNumber { get; set; }

        public string Number { get; set; }

        public string Engineer { get; set; }

        public DateTime InspectionDate { get; set; }
    }
}