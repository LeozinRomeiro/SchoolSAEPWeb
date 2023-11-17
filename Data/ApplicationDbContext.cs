using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolSAEP.Data.Mappings;
using SchoolSAEP.Models;

namespace SchoolSAEP.Data
{
    public class ApplicationDbContext : IdentityDbContext<Professor>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SchoolSAEP.Models.Professor> Professor { get; set; } = default!;
        public DbSet<SchoolSAEP.Models.Turma> Turma { get; set; } = default!;
        public DbSet<SchoolSAEP.Models.Atividade> Atividade { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new AtividadeMap());
        }
    }
}