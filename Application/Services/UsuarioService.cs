using Application.AuxiliaryClasses;
using Application.Configuration.Identity.Interfaces;
using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.AggregateModels;
using Infrastructure.Auth;
using Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioPrincipal _usuarioPrincipal;
        private readonly ITokenService _tokenService;
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly IIdentityServerLog _logger;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(UserManager<Usuario> userManager, RoleManager<Perfil> roleManager,
            IUsuarioRepository usuarioRepository, ITokenService tokenService, IMapper mapper,
            IUsuarioPrincipal usuarioPrincipal) : base(mapper) //IIdentityServerLog logger)
        {
            _userManager = userManager;
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _usuarioPrincipal = usuarioPrincipal;
            //_logger = logger;
        }

        public async Task<Result> CadastrarUsuario(CadastroUsuarioDTO dto)
        {
            var usuarioExistente = await _usuarioRepository.ConsultaUsuarioPorEmail(dto.Email.ToLower());

            if (usuarioExistente != null) { return new Result().AdicionarMensagemErro("Usuario já cadastrado!"); }

            var usuario = new Usuario(dto.Email, dto.DataNascimento, dto.Admin);

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

        public async Task<Result<UsuarioListagemViewModel>> ObterUsuarioLogado()
        {
            var usuarioVm = new UsuarioListagemViewModel
            {
                Id = _usuarioPrincipal.Id,
                Email = _usuarioPrincipal.Email,
                Admin = _usuarioPrincipal.Admin
            };

            return new Result<UsuarioListagemViewModel>(usuarioVm);
        }

        public async Task<Result<IEnumerable<UsuarioListagemViewModel>>> ListarUsuarios()
        {
            var usuarios = await _usuarioRepository.ListarUsuarios();

            if (!usuarios.Any()) { return new Result<IEnumerable<UsuarioListagemViewModel>>(); }

            var usuariosVm = Mapper.Map<IEnumerable<UsuarioListagemViewModel>>(usuarios);

            return new Result<IEnumerable<UsuarioListagemViewModel>>(usuariosVm);
        }

        public async Task<Result<IEnumerable<EquipeViewModel>>> ListarEquipesGerenciadasUsuario()
        {
            var usuario = await _usuarioRepository.ListarUsuarioPorId(_usuarioPrincipal.Id);

            var equipesVm = Mapper.Map<IEnumerable<EquipeViewModel>>(usuario.EquipesGerenciadas);

            return new Result<IEnumerable<EquipeViewModel>>(equipesVm);
        }

        public async Task<Result<IEnumerable<EquipeViewModel>>> ListarEquipesUsuario()
        {
            var usuario = await _usuarioRepository.ListarUsuarioPorId(_usuarioPrincipal.Id);

            var equipesVm = Mapper.Map<IEnumerable<EquipeViewModel>>(usuario.Equipes.Select(x => x.Equipe).ToList());

            return new Result<IEnumerable<EquipeViewModel>>(equipesVm);
        }
    }
}
