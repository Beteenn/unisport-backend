using Domain.AggregateModels;
using Infrastructure.AuxiliaryClasses;
using Infrastructure.DataAccess.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public sealed class Context 
		: IdentityDbContext<Usuario, Perfil, long>, IUnitOfWork
    {
		public Context(DbContextOptions options) : base(options)
		{
		}

		private bool DatabaseProviderInMemory => Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory";

		public void Migrate<TContext>()
		{
			var migrationsPendentes = Database.GetPendingMigrations().Any();

			if (migrationsPendentes && !DatabaseProviderInMemory)
				Database.Migrate();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Perfil>().ToTable("UsuarioPerfil").HasKey(t => t.Id);
			builder.Entity<IdentityUserClaim<long>>().ToTable("UsuarioPermissao").HasKey(t => t.Id);
			builder.Entity<IdentityUserLogin<long>>().ToTable("UsuarioLogin");
			builder.Entity<IdentityUserToken<long>>().ToTable("UsuarioToken");
			builder.Entity<IdentityRoleClaim<long>>().ToTable("PerfilPermissao").HasKey(t => t.Id);
			builder.Entity<IdentityUserRole<long>>().ToTable("UsuarioPerfilUsuario");
			
			builder.ApplyConfiguration(new UsuarioMapping());
			builder.ApplyConfiguration(new FaculdadeMapping());
			builder.ApplyConfiguration(new EquipeMapping());
			builder.ApplyConfiguration(new EquipeUsuarioMapping());
		}

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        #region Db Sets

        public DbSet<Perfil> Perfil { get; set; }
		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Faculdade> Faculdade { get; set; }
		public DbSet<Equipe> Equipe { get; set; }
		public DbSet<EquipeUsuario> EquipeUsuario { get; set; }

		#endregion
	}
}
