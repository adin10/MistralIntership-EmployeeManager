using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.API.Models
{
    public class UserUpsertRestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string CurrentPassword { get; set; }
    }
}
