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
        }
	}
}
