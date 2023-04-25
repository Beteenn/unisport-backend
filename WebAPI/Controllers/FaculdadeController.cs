using Application.DTO;
using Application.Services;
using Application.Services.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaculdadeController : BaseApiController
    {
        private readonly IFaculdadeService _fauldadeService;

        public FaculdadeController(IFaculdadeService faculdadeService)
        {
            _fauldadeService = faculdadeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FaculdadeViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListarFaculdades()
        {
            return ResultadoRetorno(await _fauldadeService.ListarFaculdades());
        }

        [Route("id")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FaculdadeViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObterFaculdadePorId(long id)
        {
            return ResultadoRetorno(await _fauldadeService.ObterFaculdadePorId(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraUsuario(CadastroFaculdadeDTO faculdadeDTO)
        {
            var result = await _fauldadeService.CadastrarFaculdade(faculdadeDTO);

            return ResultadoRetorno(result);
        }

    }
}
