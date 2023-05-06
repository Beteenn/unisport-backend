using Application.ViewModels;
using AutoMapper;
using Domain.AggregateModels;

namespace Application.Mapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Faculdade, FaculdadeViewModel>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioViewModel>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioListagemViewModel>()
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"))
                .ReverseMap();

            CreateMap<Equipe, EquipeViewModel>()
                .ForMember(dest => dest.Jogadores, opt => opt.MapFrom(src => src.Jogadores.Select(x => x.Usuario)))
                .ForMember(dest => dest.Gerente, opt => opt.MapFrom(src => src.Gerente))
                .ReverseMap();
        }
    }
}
