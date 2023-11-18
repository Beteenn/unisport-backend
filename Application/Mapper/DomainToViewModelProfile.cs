using Application.ViewModels;
using Application.ViewModels.CampeonatosVm;
using AutoMapper;
using Domain.AggregateModels;
using Domain.AggregateModels.CampeonatoModels;

namespace Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioListagemViewModel>()
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"))
                .ReverseMap();

            CreateMap<Equipe, EquipeViewModel>()
                .ForMember(dest => dest.Jogadores, opt => opt.MapFrom(src => src.Jogadores.Select(x => x.Usuario)))
                .ForMember(dest => dest.Gerente, opt => opt.MapFrom(src => src.Gerente))
                .ReverseMap();

            CreateMap<TipoCampeonato, TipoCampeonatoViewModel>()
                .ReverseMap();

            CreateMap<ModalidadeCampeonato, ModalidadeCampeonatoViewModel>()
                .ReverseMap();

            CreateMap<StatusCampeonato, StatusCampeonatoViewModel>()
                .ReverseMap();

            CreateMap<Campeonato, CampeonatoViewModel>()
                .ReverseMap();

            CreateMap<Inscricao, InscricaoViewModel>()
                .ForMember(dest => dest.Equipes, opt => opt.MapFrom(src => src.Equipes.Select(x => x.Equipe)))
                .ReverseMap();
        }
    }
}
