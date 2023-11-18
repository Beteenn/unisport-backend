using Domain.AggregateModels.CampeonatoModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICampeonatoRepository : IBaseRepository<Campeonato>
    {
        Task<IEnumerable<TipoCampeonato>> ListarTiposCampeonatos();
        Task<IEnumerable<ModalidadeCampeonato>> ListarModalidadesCampeonatos();
        Task CadastrarCampeonato(Campeonato campeonato);
        Task AtualizarCampeonato(Campeonato campeonato);
        Task<Campeonato> ObterCampeonatoPorId(long id);
        Task<IEnumerable<Campeonato>> ListarCampeonatosPorFiltro(int? tipoId, int? modalidadeId,
            bool inscricoesAbertas);
        Task UpdateCampeonato(Campeonato campeonato);
    }
}
