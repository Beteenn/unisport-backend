using Domain.AggregateModels;
using Infrastructure.Configuration;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context)
            : base(context)
        {

        }

        public async Task CadastraUsuario(Usuario usuario, string password)
        {
            await _context.AddAsync(usuario);
        }

        public async Task<Usuario> ConsultaUsuarioPorEmail(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }
    }
}
