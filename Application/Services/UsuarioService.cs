using Application.AuxiliaryClasses;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.AggregateModels;
using Infrastructure.Configuration.Logger;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly IIdentityServerLog _logger;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(UserManager<Usuario> userManager, RoleManager<Perfil> roleManager, 
            IUsuarioRepository usuarioRepository) //IIdentityServerLog logger)
        {
            _userManager = userManager;
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            //_logger = logger;
        }

        public async Task<Result> CadastrarUsuario(CadastroUsuarioDTO dto)
        {
            //var cpfUsuario = PessoaFisica.CPFSemMascara(dto.PessoaFisica.CPF);
            //var usuarioExistenteResult = await _usuarioRepository.ConsultaUsuarioPorCpf(cpfUsuario);

            //if (usuarioExistenteResult is not null)
            //    return new Result().AdicionarMensagemErro("Usuario já cadastrado!");

            //var usuario = new Usuario(dto.Username, cpfUsuario, dto.PessoaFisica.Nome, 
            //    dto.PessoaFisica.Email, dto.PessoaFisica.DataNascimento);

            //IdentityResult result = null;

            //if (string.IsNullOrEmpty(dto.Password))
            //    result = await _userManager.CreateAsync(usuario);
            //else
            //    result = await _userManager.CreateAsync(usuario, dto.Password);

            //if (result.Succeeded)
            //    return new Result();

            //return new Result().AdicionarMensagemErro(result.Errors.Select(x => x.Description));

            return new Result();
        }
    }
}
