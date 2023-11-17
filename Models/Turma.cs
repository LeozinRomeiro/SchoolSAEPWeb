using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSAEP.Models
{
    public class Turma
    {
        public int TurmaId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório, por favor insira o nome da Turma")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório, por favor insira o numero da Turma")]
        public int Numero { get; set; } = 0;
        [Required(ErrorMessage = "Campo obrigatório, por favor insira a turma")]
        public string ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        [NotMapped]
        public List<SelectListItem> Professores { get; set; }
    }
}
