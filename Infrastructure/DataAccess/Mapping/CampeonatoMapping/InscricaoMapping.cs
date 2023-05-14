using Domain.AggregateModels.CampeonatoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping.CampeonatoMapping
{
    public class InscricaoMapping : IEntityTypeConfiguration<Inscricao>
    {
        public void Configure(EntityTypeBuilder<Inscricao> builder)
        {
            builder.ToTable(nameof(Inscricao));

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Campeonato)
                .WithOne(x => x.Inscricao)
                .HasForeignKey<Inscricao>(x => x.CampeonatoId);

            builder.Property(x => x.DataInicio);
            builder.Property(x => x.DataFim);
        }
    }
}
