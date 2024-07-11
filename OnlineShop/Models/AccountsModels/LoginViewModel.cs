using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.AccountsModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "eroare email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "eroare pass 1")]
        public string Password { get; set; }
        
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
