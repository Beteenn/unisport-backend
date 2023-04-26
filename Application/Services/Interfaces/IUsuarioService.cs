using Application.AuxiliaryClasses;
using Application.DTO;
using Application.ViewModels;

namespace Application.Services.Interfaces
{
    public interface IUsuarioService
	{
		Task<Result> CadastrarUsuario(CadastroUsuarioDTO cadastroUsuarioDTO);
        Task<Result<LoginViewModel>> Login(LoginDTO loginDto);
    }
}
