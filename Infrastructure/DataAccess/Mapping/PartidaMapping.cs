using Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping
{
    public class PartidaMapping : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.ToTable(nameof(Partida));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataInicio);
            builder.Property(x => x.DataFim);
            builder.Property(x => x.Rodada);

            builder.HasOne(x => x.EquipeA)
                .WithMany()
                .HasForeignKey(x => x.EquipeAId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.EquipeB)
                .WithMany()
                .HasForeignKey(x => x.EquipeBId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.EquipeVencedora)
                .WithMany()
                .HasForeignKey(x => x.EquipeVencedoraId)
                .IsRequired(false);

            builder.HasOne(x => x.ProximaPartida)
                .WithMany()
                .HasForeignKey(x => x.ProximaPartidaId)
                .IsRequired(false);
        }
    }
}
