using Domain.AggregateModels.CampeonatoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping.CampeonatoMapping
{
    public class TipoCampeonatoMapping : IEntityTypeConfiguration<TipoCampeonato>
    {
        public void Configure(EntityTypeBuilder<TipoCampeonato> builder)
        {
            builder.ToTable(nameof(TipoCampeonato));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
