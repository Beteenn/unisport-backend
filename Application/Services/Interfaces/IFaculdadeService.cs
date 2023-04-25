using Application.AuxiliaryClasses;
using Application.DTO;
using Application.ViewModels;
using Domain.AggregateModels;

namespace Application.Services.Interfaces
{
    public interface IFaculdadeService
    {
        Task<Result<IEnumerable<FaculdadeViewModel>>> ListarFaculdades();
        Task<Result<FaculdadeViewModel>> ObterFaculdadePorId(long id);
        Task<Result> CadastrarFaculdade(CadastroFaculdadeDTO faculdadeDTO);
    }
}
