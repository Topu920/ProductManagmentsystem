using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_of_Online_Product_Management_System.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

    }
}