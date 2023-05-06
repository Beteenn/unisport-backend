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

        public async Task CadastrarCampeonato(Campeonato campeonato)
        {
            await _context.Campeonato.AddAsync(campeonato);
        }

        public async Task AtualizarCampeonato(Campeonato campeonato)
        {
            await Task.Run(() => _context.Update(campeonato));
        }

        public async Task<IEnumerable<Campeonato>> ListarCampeonatosPorFaculdadeId(long faculdadeId)
        {
            return await _context.Campeonato
                .Include(x => x.TipoCampeonato)
                .Include(x => x.StatusCampeonato)
                .Include(x => x.ModalidadeCampeonato)
                .Include(x => x.Organizador)
                .Where(x => x.Organizador.FaculdadeId == faculdadeId)
                .ToListAsync();
        }

        public async Task<Campeonato> ObterCampeonatoPorId(long id)
        {
            return await _context.Campeonato
                .Include(x => x.TipoCampeonato)
                .Include(x => x.StatusCampeonato)
                .Include(x => x.ModalidadeCampeonato)
                .Include(x => x.Organizador)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
