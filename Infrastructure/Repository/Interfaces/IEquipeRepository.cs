using Domain.AggregateModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IEquipeRepository : IBaseRepository<Equipe>
    {
        Task CriarEquipe(Equipe equipe);
        Task<Equipe> ObterEquipePorId(long id);
        Task<IEnumerable<Equipe>> ListarEquipesPorFaculdadeId(long faculdadeId);
    }
}
