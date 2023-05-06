using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : BaseApiController
    {
        private readonly IEquipeService _equipeService;

        public EquipeController(IEquipeService equipeService)
        {
            _equipeService = equipeService;
        }

        [Route("faculdade/{faculdadeId}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EquipeViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarEquipesPorFaculdadeId(long faculdadeId)
        {
            var result = await _equipeService.ListarEquipesPorFaculdadeId(faculdadeId);

            return ResultadoRetorno(result);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EquipeViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterEquipePorId(long id)
        {
            var result = await _equipeService.ObterEquipePorId(id);

            return ResultadoRetorno(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraEquipe(CriarEquipeDTO equipeDto)
        {
            var result = await _equipeService.CriarEquipe(equipeDto);

            return ResultadoRetorno(result);
        }
    }
}
