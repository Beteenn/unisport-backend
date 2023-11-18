using Application.AuxiliaryClasses;
using Application.Configuration.Identity.Interfaces;
using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.AggregateModels;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly ITokenService _tokenService;
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly IIdentityServerLog _logger;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(UserManager<Usuario> userManager, RoleManager<Perfil> roleManager, 
            IUsuarioRepository usuarioRepository, ITokenService tokenService, IMapper mapper) : base(mapper) //IIdentityServerLog logger)
        {
            _userManager = userManager;
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            //_logger = logger;
        }

        public async Task<Result> CadastrarUsuario(CadastroUsuarioDTO dto)
        {
            var usuarioExistente = await _usuarioRepository.ConsultaUsuarioPorEmail(dto.Email.ToLower());

            if (usuarioExistente != null) { return new Result().AdicionarMensagemErro("Usuario já cadastrado!"); }

            var usuario = new Usuario(dto.Nome, dto.Sobrenome, dto.Email, dto.DataNascimento);

            IdentityResult result = null;

            if (string.IsNullOrEmpty(dto.Password))
                result = await _userManager.CreateAsync(usuario);
            else
                result = await _userManager.CreateAsync(usuario, dto.Password);

            if (!result.Succeeded) { return new Result().AdicionarMensagemErro(result.Errors.Select(x => x.Description)); }

            return new Result();
        }

        public async Task<Result<LoginViewModel>> Login(LoginDTO loginDto)
        {
            var usuario = await _usuarioRepository.ConsultaUsuarioPorEmail(loginDto.email);

            if (usuario == null) { return new Result<LoginViewModel>().AdicionarMensagemErro("Usúario ou senha inválidos."); }

            if (!await _userManager.CheckPasswordAsync(usuario, loginDto.password))
            {
                return new Result<LoginViewModel>().AdicionarMensagemErro("Usúario ou senha inválidos.");
            }

            var token = _tokenService.GerarToken(usuario);

            return new Result<LoginViewModel>(new LoginViewModel { Token = token });
        }

        public async Task<Result<IEnumerable<UsuarioListagemViewModel>>> ListarUsuarios()
        {
            var usuarios = await _usuarioRepository.ListarUsuarios();

            if (!usuarios.Any()) { return new Result<IEnumerable<UsuarioListagemViewModel>>(); }

            var usuariosVm = Mapper.Map<IEnumerable<UsuarioListagemViewModel>>(usuarios);

            return new Result<IEnumerable<UsuarioListagemViewModel>>(usuariosVm);
        }
    }
}
