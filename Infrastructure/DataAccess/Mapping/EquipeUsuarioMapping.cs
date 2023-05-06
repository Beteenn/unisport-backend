using Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Mapping
{
    public class EquipeUsuarioMapping : IEntityTypeConfiguration<EquipeUsuario>
    {
        public void Configure(EntityTypeBuilder<EquipeUsuario> builder)
        {
            builder.ToTable(nameof(EquipeUsuario));

            builder.HasKey(x => new { x.EquipeId, x.UsuarioId});

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Equipes)
                .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.Equipe)
                .WithMany(x => x.Jogadores)
                .HasForeignKey(x => x.EquipeId);
        }
    }
}
