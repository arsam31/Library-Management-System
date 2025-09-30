using System.ComponentModel.DataAnnotations;

namespace Library.Auth.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
    }
}
