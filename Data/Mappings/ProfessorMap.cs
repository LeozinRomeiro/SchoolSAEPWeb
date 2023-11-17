using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSAEP.Models;

namespace SchoolSAEP.Data.Mappings
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR(50)");

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("Senha");
        }
    }
}
