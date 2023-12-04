using Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping
{
    public class EquipeMapping : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable(nameof(Equipe));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(80)
                .IsRequired();

            builder.HasOne(x => x.Gerente)
                .WithMany(x => x.EquipesGerenciadas)
                .HasForeignKey(x => x.GerenteId);
        }
    }
}
