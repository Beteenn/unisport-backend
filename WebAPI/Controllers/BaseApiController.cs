using Application.AuxiliaryClasses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public abstract class BaseApiController : ControllerBase
	{
        protected IActionResult ResultadoRetorno<T>(Result<T> result)
            where T : class
        {
            if (!result.Sucesso)
                return BadRequest(result);

            if (result.Data == null)
                return NotFound();

            return Ok(result.Data);
        }

        protected IActionResult ResultadoRetorno(Result result, string mensagemStatusOK = "")
        {
            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(mensagemStatusOK);
        }
    }
}
