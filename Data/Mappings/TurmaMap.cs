using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolSAEP.Models;

namespace SchoolSAEP.Data.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable(nameof(Turma));
            builder.HasKey(x=>x.TurmaId);
            builder.Property(x => x.TurmaId)
                .ValueGeneratedNever() 
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.Numero)
                .IsRequired()
                .HasColumnName("Numero")
                .HasColumnType("INT");

            builder.HasOne(x => x.Professor)
                .WithMany()
                .HasForeignKey(x => x.ProfessorId)
                .HasConstraintName("FK_Turma_Professor");
        }
    }
}
