using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolSAEP.Models;

namespace SchoolSAEP.Data.Mappings
{
    public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable(nameof(Turma));
            builder.HasKey(x => x.TurmaId);
            builder.Property(x => x.TurmaId)
                .ValueGeneratedNever()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR(50)");


            builder.HasOne(x => x.Turma)
                .WithMany()
                .HasForeignKey(x => x.TurmaId)
                .HasConstraintName("FK_Atividade_Turma");
        }
    }
}
