using Application.AuxiliaryClasses;
using Application.Services.Interfaces;
using Application.ViewModels.CampeonatosVm;
using AutoMapper;
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
    }
}
