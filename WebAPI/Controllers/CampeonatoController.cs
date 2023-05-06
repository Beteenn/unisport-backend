using Application.Services.Interfaces;
using Application.ViewModels;
using Application.ViewModels.CampeonatosVm;
using Microsoft.AspNetCore.Http;
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
    }
}
