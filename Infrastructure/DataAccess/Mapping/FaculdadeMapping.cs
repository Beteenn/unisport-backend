using Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping
{
    public class FaculdadeMapping : IEntityTypeConfiguration<Faculdade>
    {
        public void Configure(EntityTypeBuilder<Faculdade> builder)
        {
            builder.ToTable(nameof(Faculdade));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(80);

            builder.Property(x => x.DominioEmail)
                .HasMaxLength(80);
        }
    }
}
