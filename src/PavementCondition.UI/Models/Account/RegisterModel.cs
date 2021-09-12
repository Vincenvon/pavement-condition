using System.ComponentModel.DataAnnotations;

namespace PavementCondition.UI.Models.Account
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }
    }
}
