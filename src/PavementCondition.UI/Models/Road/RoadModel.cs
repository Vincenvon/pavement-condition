using System.ComponentModel.DataAnnotations;

namespace PavementCondition.UI.Models.Road
{
    public class RoadModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Number { get; set; }

        [Required]
        [MaxLength(100)]
        public string StartPoint { get; set; }

        [Required]
        [MaxLength(100)]
        public string EndPoint { get; set; }

        public decimal Distance { get; set; }

        [Required]
        [MaxLength(100)]
        public string ServiceOrganization { get; set; }
    }
}
