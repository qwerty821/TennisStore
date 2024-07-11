using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.AccountsModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "First Name must have at least 2 characters")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Last Name must have at least 2 characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        
        [Required]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}