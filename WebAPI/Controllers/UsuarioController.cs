using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : BaseApiController
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarUsuarios()
        {
            var result = await _usuarioService.ListarUsuarios();

            return ResultadoRetorno(result);
        }

        [Route("faculdade/{faculdadeId}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarUsuariosPorFaculdadeId(long faculdadeId)
        {
            var result = await _usuarioService.ListarUsuariosPorFaculdadeId(faculdadeId);

            return ResultadoRetorno(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            var result = await _usuarioService.CadastrarUsuario(usuarioDTO);

            return ResultadoRetorno(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var result = await _usuarioService.Login(loginDto);

            return ResultadoRetorno(result);
        }
    }
}
