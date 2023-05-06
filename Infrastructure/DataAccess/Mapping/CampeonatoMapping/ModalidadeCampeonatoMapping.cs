using Domain.AggregateModels.CampeonatoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping.CampeonatoMapping
{
    public class ModalidadeCampeonatoMapping : IEntityTypeConfiguration<ModalidadeCampeonato>
    {
        public void Configure(EntityTypeBuilder<ModalidadeCampeonato> builder)
        {
            builder.ToTable(nameof(ModalidadeCampeonato));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
