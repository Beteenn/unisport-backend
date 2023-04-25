using Domain.AggregateModels;

namespace Infrastructure.Repository.Interfaces
{
    public interface IFaculdadeRepository : IBaseRepository<Faculdade>
    {
        Task<IEnumerable<Faculdade>> ListarFaculdades();
        Task<Faculdade> ObterFaculdadePorId(long id);
        Task CadastrarFaculdade(Faculdade faculdade);
    }
}
