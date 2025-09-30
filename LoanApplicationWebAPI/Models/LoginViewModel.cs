using System.ComponentModel.DataAnnotations;

namespace LoanApplicationWebAPI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email or Username is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } // or you can use Username if preferred

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
