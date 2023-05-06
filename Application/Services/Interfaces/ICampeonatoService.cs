using Application.AuxiliaryClasses;
using Application.ViewModels.CampeonatosVm;

namespace Application.Services.Interfaces
{
    public interface ICampeonatoService
    {
        Task<Result<IEnumerable<ModalidadeCampeonatoViewModel>>> ListarModalidadesCampeonato();
        Task<Result<IEnumerable<TipoCampeonatoViewModel>>> ListarTiposCampeonato();
    }
}
