using Domain.AggregateModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
	{
		Task CadastraUsuario(Usuario usuario, string password);
        Task<Usuario> ConsultaUsuarioPorEmail(string email);
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<IEnumerable<Usuario>> ListarUsuarioPorFaculdadeId(long faculdadeId);
        Task<IEnumerable<Usuario>> ListarUsuariosPorIds(IEnumerable<long> usuariosId);
        Task<Usuario> ListarUsuarioPorId(long id);
        Task AtualizarUsuario(Usuario usuario);
    }
}
