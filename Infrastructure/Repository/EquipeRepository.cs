using Domain.AggregateModels;
using Domain.AggregateModels.CampeonatoModels;
using Infrastructure.Configuration;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EquipeRepository : BaseRepository<Equipe>, IEquipeRepository
    {
        public EquipeRepository(Context context) : base(context) { }

        public async Task CriarEquipe(Equipe equipe)
        {
            await _context.AddAsync(equipe);
        }

        public Task AtualizarEquipe(Equipe equipe)
        {
            return Task.Run(() => _context.Update(equipe));
        }

        public async Task<Equipe> ObterEquipePorId(long id)
        {
            return await _context.Equipe
                .Include(x => x.Gerente)
                .Include(x => x.Jogadores)
                    .ThenInclude(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Equipe>> ListarEquipes()
        {
            return await _context.Equipe
                .Include(x => x.Gerente)
                .Include(x => x.Jogadores)
                    .ThenInclude(x => x.Usuario)
                .ToListAsync();
        }

        public async Task DeletarEquipe(Equipe equipe)
        {
            await Task.Run(() => _context.Remove(equipe));
        }
    }
}
