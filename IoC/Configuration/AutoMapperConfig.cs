using Application.Mapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC.Configuration
{
	public class AutoMapperConfig
	{
        private IMapper _mapper;

        public AutoMapperConfig()
        {
            try
            {
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DomainToViewModelProfile());
                    mc.AddProfile(new ViewModelToDomainProfile());
                });

                _mapper = mapperConfig.CreateMapper();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Automapper: ", ex);
            }
        }

        public IMapper Mapper => _mapper;
    }
}
