using Domain.AggregateModels.CampeonatoModels;
using Infrastructure.Configuration;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CampeonatoRepository : BaseRepository<Campeonato>, ICampeonatoRepository
    {
        public CampeonatoRepository(Context context) : base(context) { }

        public async Task<IEnumerable<ModalidadeCampeonato>> ListarModalidadesCampeonatos()
        {
            return await _context.ModalidadeCampeonato.ToListAsync();
        }

        public async Task<IEnumerable<TipoCampeonato>> ListarTiposCampeonatos()
        {
            return await _context.TipoCampeonato.ToListAsync();
        }
    }
}
