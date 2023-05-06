using Domain.AggregateModels.CampeonatoModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICampeonatoRepository : IBaseRepository<Campeonato>
    {
        Task<IEnumerable<TipoCampeonato>> ListarTiposCampeonatos();
        Task<IEnumerable<ModalidadeCampeonato>> ListarModalidadesCampeonatos();
    }
}
