using System.ComponentModel.DataAnnotations;

namespace SchoolSAEP.Models
{
    public class Atividade
    {
        public int AtividadeId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório, por favor insira o nome da atividade")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório, por favor insira a turma")]
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}
