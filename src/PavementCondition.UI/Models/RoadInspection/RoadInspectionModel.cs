using System;
using System.ComponentModel.DataAnnotations;

namespace PavementCondition.UI.Models.RoadInspection
{
    public class RoadInspectionModel
    {
        public int Id { get; set; }

        [Required]
        public int RoadId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Number { get; set; }

        [Required]
        [MaxLength(200)]
        public string Engineer { get; set; }

        [Required]
        public DateTime InspectionDate { get; set; }
    }
}
