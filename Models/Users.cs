using System.ComponentModel.DataAnnotations;

namespace Project_of_Online_Product_Management_System.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


        public int ActorId { get; set; }

        public Actor Actor { get; set; }


    }
}
