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

        public Task AtualizarUsuario(Usuario usuario)
        {
            return Task.Run(() => _context.Update(usuario));
        }

        public async Task CadastraUsuario(Usuario usuario, string password)
        {
            await _context.AddAsync(usuario);
        }

        public async Task<Usuario> ConsultaUsuarioPorEmail(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarioPorFaculdadeId(long faculdadeId)
        {
            return await _context.Usuario
                .Include(x => x.Faculdade)
                .Where(x => x.FaculdadeId == faculdadeId && x.Ativo)
                .ToListAsync();
        }

        public async Task<Usuario> ListarUsuarioPorId(long id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id && x.Ativo);
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await _context.Usuario
                .Include(x => x.Faculdade)
                .Where(x => x.Ativo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ListarUsuariosPorIds(IEnumerable<long> usuariosId)
        {
            return await _context.Usuario
                .Include(x => x.Faculdade)
                .Where(x => usuariosId.Contains(x.Id) && x.Ativo)
                .ToListAsync();
        }
    }
}
