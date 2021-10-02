using System;
using System.ComponentModel.DataAnnotations;

namespace PavementCondition.UI.Models.DefectType
{
    public class DefectTypeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
