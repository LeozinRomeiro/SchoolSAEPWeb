using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolSAEP.Models
{
    public class Professor : IdentityUser
    {
        [Required(ErrorMessage = "Campo obrigatório, por favor insira o nome do professor")]
        public string Nome { get; set; }
    }
}
