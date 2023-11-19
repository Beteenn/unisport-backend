using Application.AuxiliaryClasses;
using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.AggregateModels;
using Infrastructure.Repository.Interfaces;

namespace Application.Services
{
    public class EquipeService : BaseService, IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EquipeService(IMapper mapper, IEquipeRepository equipeRepository, IUsuarioRepository usuarioRepository) : base(mapper)
        {
            _equipeRepository = equipeRepository;
            _usuarioRepository = usuarioRepository;
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
    }
}
