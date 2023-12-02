using Application.AuxiliaryClasses;
using Application.DTO;
using Application.ViewModels;

namespace Application.Services.Interfaces
{
    public interface IEquipeService
    {
        Task<Result> CriarEquipe(CriarEquipeDTO equipeDto);
        Task<Result<EquipeViewModel>> ObterEquipePorId(long id);
        Task<Result<IEnumerable<EquipeViewModel>>> ListarEquipes();
        Task<Result> AtualizaEquipe(AtualizaEquipeDTO equipeDto);
        Task<Result> IngressarEquipe(IngressarEquipeDTO ingressoDto);
        Task<Result> DeletarEquipe(long id);
    }
}
