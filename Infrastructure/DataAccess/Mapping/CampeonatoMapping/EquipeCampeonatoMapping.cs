using Domain.AggregateModels.CampeonatoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping.CampeonatoMapping
{
    public class EquipeCampeonatoMapping : IEntityTypeConfiguration<EquipeCampeonato>
    {
        public void Configure(EntityTypeBuilder<EquipeCampeonato> builder)
        {
            builder.ToTable(nameof(EquipeCampeonato));

            builder.HasKey(x => new { x.EquipeId, x.CampeonatoId });

            builder.HasOne(x => x.Campeonato)
                .WithMany(x => x.Equipes)
                .HasForeignKey(x => x.CampeonatoId);

            builder.HasOne(x => x.Equipe)
                .WithMany(x => x.Campeonatos)
                .HasForeignKey(x => x.EquipeId);
        }
    }
}
