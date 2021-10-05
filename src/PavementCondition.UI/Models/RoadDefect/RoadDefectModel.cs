using System.ComponentModel.DataAnnotations;

namespace PavementCondition.UI.Models.RoadDefect
{
    public class RoadDefectModel
    {
        public int Id { get; set; }

        [Required]
        public int RoadInspectionId { get; set; }

        [Required]
        public int DefectTypeId { get; set; }

        [Required]
        public decimal DefectStartPoint { get; set; }

        [Required]
        public decimal DefectDistance { get; set; }
    }
}
