using Domain.AggregateModels.CampeonatoModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping.CampeonatoMapping
{
    public class CampeonatoMapping : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.ToTable(nameof(Campeonato));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.QuantidadeRodadas);

            builder.HasOne(x => x.TipoCampeonato)
                .WithMany()
                .HasForeignKey(x => x.TipoCampeonatoId);

            builder.HasOne(x => x.StatusCampeonato)
                .WithMany()
                .HasForeignKey(x => x.StatusCampeonatoId);

            builder.HasOne(x => x.ModalidadeCampeonato)
                .WithMany()
                .HasForeignKey(x => x.ModalidadeCampeonatoId);

            builder.Property(x => x.DataInicio);
            builder.Property(x => x.DataFim);

            builder.HasOne(x => x.Organizador)
                .WithMany()
                .HasForeignKey(x => x.OrganizadorId);
        }
    }
}
