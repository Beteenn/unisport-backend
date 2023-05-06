using Domain.AggregateModels.CampeonatoModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Mapping.CampeonatoMapping
{
    public class StatusCampeonatoMapping : IEntityTypeConfiguration<StatusCampeonato>
    {
        public void Configure(EntityTypeBuilder<StatusCampeonato> builder)
        {
            builder.ToTable(nameof(StatusCampeonato));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
