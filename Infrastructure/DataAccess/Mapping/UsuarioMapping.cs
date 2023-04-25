using Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(80);

            builder.Property(x => x.Sobrenome)
                .HasMaxLength(80);

            builder.Property(x => x.Ativo)
                .HasDefaultValue(false);

            builder.Property(x => x.DataNascimento);

            builder.HasOne(x => x.Faculdade)
                .WithMany()
                .HasForeignKey(x => x.FaculdadeId);
        }
    }
}
