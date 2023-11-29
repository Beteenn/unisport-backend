using Application.AuxiliaryClasses;
using Application.DTO.CampeonatosDTO;
using Application.Services.Interfaces;
using Application.ViewModels.CampeonatosVm;
using AutoMapper;
using Domain.AggregateModels.CampeonatoModels;
using Infrastructure.Repository.Interfaces;

namespace Application.Services
{
    public class CampeonatoService : BaseService, ICampeonatoService
    {
        private readonly ICampeonatoRepository _campeonatoRepository;

        public CampeonatoService(IMapper mapper, ICampeonatoRepository campeonatoRepository) : base(mapper)
        {
            _campeonatoRepository = campeonatoRepository;
        }

        public async Task<Result<IEnumerable<ModalidadeCampeonatoViewModel>>> ListarModalidadesCampeonato()
        {
            var modalidades = await _campeonatoRepository.ListarModalidadesCampeonatos();

            if (!modalidades.Any())
            {
                return new Result<IEnumerable<ModalidadeCampeonatoViewModel>>().AdicionarMensagemErro("Nenhum modalidade encontrada.");
            }

            var modalidadesVm = Mapper.Map<IEnumerable<ModalidadeCampeonatoViewModel>>(modalidades);

            return new Result<IEnumerable<ModalidadeCampeonatoViewModel>>(modalidadesVm);
        }

        public async Task<Result<IEnumerable<TipoCampeonatoViewModel>>> ListarTiposCampeonato()
        {
            var tipos = await _campeonatoRepository.ListarTiposCampeonatos();

            if (!tipos.Any())
            {
                return new Result<IEnumerable<TipoCampeonatoViewModel>>().AdicionarMensagemErro("Nenhum tipo encontrado.");
            }

            var tiposVm = Mapper.Map<IEnumerable<TipoCampeonatoViewModel>>(tipos);

            return new Result<IEnumerable<TipoCampeonatoViewModel>>(tiposVm);
        }

        public async Task<Result<CampeonatoViewModel>> ObterCampeonatoPorId(long id)
        {
            var campeonato = await _campeonatoRepository.ObterCampeonatoPorId(id);

            if (campeonato == null) { return new Result<CampeonatoViewModel>().AdicionarMensagemErro("Nenhum campeonato encontrado."); }

            var campeonatoVm = Mapper.Map<CampeonatoViewModel>(campeonato);

            return new Result<CampeonatoViewModel>(campeonatoVm);
        }

        public async Task<Result<IEnumerable<CampeonatoViewModel>>> ListarCampeonatosPorFiltro(int? tipoId, int? modalidadeId,
            bool inscricoesAbertas)
        {
            var campeonatos = await _campeonatoRepository.ListarCampeonatosPorFiltro(tipoId, modalidadeId, inscricoesAbertas);

            if (!campeonatos.Any())
            {
                return new Result<IEnumerable<CampeonatoViewModel>>().AdicionarMensagemErro("Nenhum campeonato encontrado");
            }

            var campeonatosVm = Mapper.Map<IEnumerable<CampeonatoViewModel>>(campeonatos);

            return new Result<IEnumerable<CampeonatoViewModel>>(campeonatosVm);
        }

        public async Task<Result> CadastrarCampeonato(CadastrarCampeonatoDTO campeonatoDto)
        {
            var campeonato = new Campeonato(campeonatoDto.Nome, campeonatoDto.TipoId,
                campeonatoDto.ModalidadeId, campeonatoDto.DataInicio, campeonatoDto.DataFim,
                campeonatoDto.OrganizadorId, campeonatoDto.DataInicioInscricao, campeonatoDto.DataFimInscricao);

            await _campeonatoRepository.CadastrarCampeonato(campeonato);
            await _campeonatoRepository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }

        public async Task<Result> AtualizarCampeonato(AtualizarCampeonatoDTO campeonatoDto)
        {
            var campeonato = await _campeonatoRepository.ObterCampeonatoPorId(campeonatoDto.Id);

            if (campeonato == null) { return new Result().AdicionarMensagemErro("Campeonato não encontrado."); }

            campeonato.Atualizar(campeonatoDto.Nome, campeonatoDto.ModalidadeId, campeonatoDto.TipoId,
                campeonatoDto.DataInicio, campeonatoDto.DataFim,
                campeonatoDto.DataInicioInscricao, campeonatoDto.DataFimInscricao);

            await _campeonatoRepository.AtualizarCampeonato(campeonato);
            await _campeonatoRepository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }

        public async Task<Result> IncreverEquipeNoCampeonato(InscreverEquipeNoCampeonatoDTO inscricaoDto)
        {
            var campeonato = await _campeonatoRepository.ObterCampeonatoPorId(inscricaoDto.CampeonatoId);

            if (campeonato == null) { return new Result().AdicionarMensagemErro("Campeonato não encontrado."); }

            campeonato.AdicionarEquipe(inscricaoDto.EquipeId);

            await _campeonatoRepository.AtualizarCampeonato(campeonato);
            await _campeonatoRepository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }

        public async Task<Result> DeletarCampeonato(long id)
        {
            var campeonato = await _campeonatoRepository.ObterCampeonatoPorId(id);

            if (campeonato == null) { return new Result().AdicionarMensagemErro("Campeonato não encontrado."); }

            await _campeonatoRepository.DeletarCampeonato(campeonato);
            await _campeonatoRepository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }
    }
}
