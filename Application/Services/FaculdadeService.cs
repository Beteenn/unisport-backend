using Application.AuxiliaryClasses;
using Application.DTO;
using Application.Services.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.AggregateModels;
using Infrastructure.Repository.Interfaces;

namespace Application.Services
{
    public class FaculdadeService : BaseService, IFaculdadeService
    {
        private readonly IFaculdadeRepository _faculdadeRespository;

        public FaculdadeService(IMapper mapper, IFaculdadeRepository faculdadeRepository) : base(mapper)
        {
            _faculdadeRespository = faculdadeRepository;
        }

        public async Task<Result<IEnumerable<FaculdadeViewModel>>> ListarFaculdades()
        {
            var faculdades = await _faculdadeRespository.ListarFaculdades();

            var faculdadesVm = Mapper.Map<IEnumerable<FaculdadeViewModel>>(faculdades);

            return new Result<IEnumerable<FaculdadeViewModel>>(faculdadesVm);
        }

        public async Task<Result<FaculdadeViewModel>> ObterFaculdadePorId(long id)
        {
            var faculdade = await _faculdadeRespository.ObterFaculdadePorId(id);

            var faculdadeVm = Mapper.Map<FaculdadeViewModel>(faculdade);

            return new Result<FaculdadeViewModel>(faculdadeVm);
        }

        public async Task<Result> CadastrarFaculdade(CadastroFaculdadeDTO faculdadeDTO)
        {
            await _faculdadeRespository.CadastrarFaculdade(new Faculdade(faculdadeDTO.Nome, faculdadeDTO.Dominio));
            await _faculdadeRespository.UnitOfWork.SaveChangesAsync();

            return new Result();
        }
    }
}
