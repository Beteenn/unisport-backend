using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UsuarioViewModel>), StatusCodes.Status200OK),
            ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CadastraUsuario(CadastroUsuarioDTO usuarioDTO)
        {
            var result = await _usuarioService.CadastrarUsuario(usuarioDTO);

            return ResultadoRetorno(result);
        }
    }
}
