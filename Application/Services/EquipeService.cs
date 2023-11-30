using Application.AuxiliaryClasses;
using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.AggregateModels;
using Infrastructure.Auth;
using Infrastructure.Repository.Interfaces;

namespace Application.Services
{
    public class EquipeService : BaseService, IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioPrincipal _usuarioPrincipal;

        public EquipeService(IMapper mapper, IEquipeRepository equipeRepository,
            IUsuarioRepository usuarioRepository, IUsuarioPrincipal usuarioPrincipal) : base(mapper)
        {
            _equipeRepository = equipeRepository;
            _usuarioRepository = usuarioRepository;
            _usuarioPrincipal = usuarioPrincipal;
        }

        public async Task<Result> CriarEquipe(CriarEquipeDTO equipeDto)
        {
            var usuario = await _usuarioRepository.ListarUsuarioPorId(equipeDto.GerenteId);

            var equipe = new Equipe(usuario.Id, equipeDto.Nome);

            equipe.AdicionarJogadores(equipeDto.JogadoresId);
            usuario.AdicionarEquipeGerenciada(equipe);

            await _usuarioRepository.AtualizarUsuario(usuario);

            await _equipeRepository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }

        public async Task<Result<IEnumerable<EquipeViewModel>>> ListarEquipes()
        {
            var equipes = await _equipeRepository.ListarEquipes();

            if (!equipes.Any())
            {
                return new Result<IEnumerable<EquipeViewModel>>()
                    .AdicionarMensagemErro("Nenhuma equipe encontrada.");
            }

            var equipesVm = Mapper.Map<IEnumerable<EquipeViewModel>>(equipes);

            return new Result<IEnumerable<EquipeViewModel>>(equipesVm);
        }

        public async Task<Result<EquipeViewModel>> ObterEquipePorId(long id)
        {
            var equipe = await _equipeRepository.ObterEquipePorId(id);

            if (equipe == null)
            {
                return new Result<EquipeViewModel>()
                    .AdicionarMensagemErro("Equipe não encontrada.");
            }

            var equipeVm = Mapper.Map<EquipeViewModel>(equipe);

            return new Result<EquipeViewModel>(equipeVm);
        }

        public async Task<Result> AtualizaEquipe(AtualizaEquipeDTO equipeDto)
        {
            var equipe = await _equipeRepository.ObterEquipePorId(equipeDto.Id);

            if (equipe == null)
            {
                return new Result()
                    .AdicionarMensagemErro("Equipe não encontrada.");
            }

            if (equipe.GerenteId != _usuarioPrincipal.Id)
            {
                return new Result()
                    .AdicionarMensagemErro("Equipe não pertence ao usuario.");
            }

            equipe.AtualizarNome(equipeDto.Nome);

            await _equipeRepository.AtualizarEquipe(equipe);
            await _equipeRepository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }

        public async Task<Result> IngressarEquipe(IngressarEquipeDTO ingressoDto)
        {
            var equipe = await _equipeRepository.ObterEquipePorId(ingressoDto.EquipeId);

            if (equipe == null)
            {
                return new Result()
                    .AdicionarMensagemErro("Equipe não encontrada.");
            }

            var usuario = await _usuarioRepository.ListarUsuarioPorId(ingressoDto.UsuarioId);

            if (usuario == null)
            {
                return new Result()
                    .AdicionarMensagemErro("Usuario não encontrado.");
            }

            if (equipe.Jogadores.Any(x => x.UsuarioId == usuario.Id))
            {
                return new Result()
                    .AdicionarMensagemErro("Jogador já pertence a equipe.");
            }

            equipe.AdicionarJogador(usuario.Id);

            await _equipeRepository.AtualizarEquipe(equipe);
            await _equipeRepository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }
    }
}
