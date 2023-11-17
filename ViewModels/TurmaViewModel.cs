using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolSAEP.ViewModels
{
    public class TurmaViewModel
    {
        public int ProfessorId { get; set; }
        public List<SelectListItem> Professores { get; set; }
    }
}
