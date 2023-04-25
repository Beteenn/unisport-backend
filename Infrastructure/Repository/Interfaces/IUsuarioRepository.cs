using Domain.AggregateModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
	{
		Task CadastraUsuario(Usuario usuario, string password);
	}
}
