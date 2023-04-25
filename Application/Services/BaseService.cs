using AutoMapper;

namespace Application.Services
{
    public abstract class BaseService
	{
        private readonly IMapper _mapper;
        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IMapper Mapper => _mapper;
    }
}
