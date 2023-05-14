using Application.DTO.CampeonatosDTO;
using Application.Services.Interfaces;
using Application.ViewModels.CampeonatosVm;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : BaseApiController
    {
        private readonly ICampeonatoService _campeonatoService;

        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }

        [Route("tipo")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TipoCampeonatoViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarTiposCampeonato()
        {
            var result = await _campeonatoService.ListarTiposCampeonato();

            return ResultadoRetorno(result);
        }

        [Route("modalidade")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ModalidadeCampeonatoViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarModalidadesCampeonato()
        {
            var result = await _campeonatoService.ListarModalidadesCampeonato();

            return ResultadoRetorno(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastrarCampeoanto(CadastrarCampeonatoDTO campeonatoDto)
        {
            var result = await _campeonatoService.CadastrarCampeonato(campeonatoDto);

            return ResultadoRetorno(result);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CampeonatoViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterCampeonatoPorId(long id)
        {
            var result = await _campeonatoService.ObterCampeonatoPorId(id);

            return ResultadoRetorno(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CampeonatoViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarCampeonatosPorFiltro(long? faculdadeId, int? tipoId, int? modalidadeId, bool inscricoesAbertas)
        {
            var result = await _campeonatoService.ListarCampeonatosPorFiltro(faculdadeId, tipoId, modalidadeId, inscricoesAbertas);

            return ResultadoRetorno(result);
        }

        [Route("inscrever")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IncreverEquipeNoCampeonato(InscreverEquipeNoCampeonatoDTO inscricaoDto)
        {
            var result = await _campeonatoService.IncreverEquipeNoCampeonato(inscricaoDto);

            return ResultadoRetorno(result);
        }
    }
}
