using Domain.AggregateModels.CampeonatoModels;

namespace Infrastructure.DataAccess.Mapping.CampeonatoMapping
{
    public class EquipeInscricaoMapping : IEntityTypeConfiguration<EquipeInscricao>
    {
        public void Configure(EntityTypeBuilder<EquipeInscricao> builder)
        {
            builder.ToTable(nameof(EquipeInscricao));

            builder.HasKey(x => new { x.EquipeId, x.InscricaoId });

            builder.HasOne(x => x.Inscricao)
                .WithMany(x => x.Equipes)
                .HasForeignKey(x => x.InscricaoId);

            builder.HasOne(x => x.Equipe)
                .WithMany(x => x.Campeonatos)
                .HasForeignKey(x => x.EquipeId);
        }
    }
}
