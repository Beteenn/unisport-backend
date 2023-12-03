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

        public async Task DeletarCampeonato(Campeonato campeonato)
        {
            await Task.Run(() => _context.Remove(campeonato));
        }

        public async Task<IEnumerable<Campeonato>> ListarCampeonatosPorFiltro(int? tipoId, int? modalidadeId,
            bool inscricoesAbertas)
        {
            var query = _context.Campeonato
                .Include(x => x.TipoCampeonato)
                .Include(x => x.StatusCampeonato)
                .Include(x => x.ModalidadeCampeonato)
                .Include(x => x.Organizador)
                .Include(x => x.Inscricao)
                    .ThenInclude(x => x.Equipes)
                .Where(x => x.Id > 0);

            if (tipoId.HasValue)
            {
                query = query.Where(x => x.TipoCampeonatoId == tipoId.Value);
            }

            if (modalidadeId.HasValue)
            {
                query = query.Where(x => x.ModalidadeCampeonatoId == modalidadeId.Value);
            }

            if (inscricoesAbertas)
            {
                query = query.Where(x => DateTime.Now.Date < x.Inscricao.DataFim.Date);
            }
            else
            {
                query = query.Where(x => DateTime.Now.Date > x.Inscricao.DataFim.Date);
            }

            return await query.ToListAsync();
        }

        public async Task<Campeonato> ObterCampeonatoPorId(long id)
        {
            return await _context.Campeonato
                .Include(x => x.TipoCampeonato)
                .Include(x => x.StatusCampeonato)
                .Include(x => x.ModalidadeCampeonato)
                .Include(x => x.Organizador)
                .Include(x => x.Partidas)
                    .ThenInclude(x => x.ProximaPartida)
                .Include(x => x.Inscricao)
                    .ThenInclude(x => x.Equipes)
                    .ThenInclude(x => x.Equipe)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
