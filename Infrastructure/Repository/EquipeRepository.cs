using Domain.AggregateModels;
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

        public async Task<Equipe> ObterEquipePorId(long id)
        {
            return await _context.Equipe
                .Include(x => x.Gerente)
                .Include(x => x.Jogadores)
                    .ThenInclude(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Equipe>> ListarEquipesPorFaculdadeId(long faculdadeId)
        {
            return await _context.Equipe
                .Include(x => x.Gerente)
                .Include(x => x.Jogadores)
                    .ThenInclude(x => x.Usuario)
                .ToListAsync();
        }
    }
}
