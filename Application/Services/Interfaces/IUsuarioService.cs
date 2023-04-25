using Application.AuxiliaryClasses;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
	public interface IUsuarioService
	{
		Task<Result> CadastrarUsuario(CadastroUsuarioDTO cadastroUsuarioDTO);
	}
}
