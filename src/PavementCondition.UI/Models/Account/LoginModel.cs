using System.ComponentModel.DataAnnotations;

namespace PavementCondition.UI.Models.Account
{
    public class LoginModel
    {
        [EmailAddress]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
