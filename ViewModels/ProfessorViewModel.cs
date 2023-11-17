using System.ComponentModel.DataAnnotations;

namespace SchoolSAEP.ViewModels
{
    public class ProfessorViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Lembre de mim")]
        public bool RememberMe { get; set; }
    }
}
