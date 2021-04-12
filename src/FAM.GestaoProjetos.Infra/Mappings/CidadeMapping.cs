using FAM.GestaoProjetos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FAM.GestaoProjetos.Infra.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.ToTable("cidade");
        }
    }
}
