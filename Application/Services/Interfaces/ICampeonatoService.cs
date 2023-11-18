using Application.AuxiliaryClasses;
using Application.DTO.CampeonatosDTO;
using Application.ViewModels.CampeonatosVm;

namespace Application.Services.Interfaces
{
    public interface ICampeonatoService
    {
        Task<Result<IEnumerable<ModalidadeCampeonatoViewModel>>> ListarModalidadesCampeonato();
        Task<Result<IEnumerable<TipoCampeonatoViewModel>>> ListarTiposCampeonato();
        Task<Result> CadastrarCampeonato(CadastrarCampeonatoDTO campeonatoDto);
        Task<Result<CampeonatoViewModel>> ObterCampeonatoPorId(long id);
        Task<Result<IEnumerable<CampeonatoViewModel>>> ListarCampeonatosPorFiltro(int? tipoId, int? modalidadeId,
            bool inscricoesAbertas);
        Task<Result> IncreverEquipeNoCampeonato(InscreverEquipeNoCampeonatoDTO inscricaoDto);
    }
}
