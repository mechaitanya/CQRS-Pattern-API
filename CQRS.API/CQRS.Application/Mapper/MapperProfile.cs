using CQRS.Application.Dto;
using CQRS.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Mapper
{
    public class MapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<City, CityDto>()
            // .Map(dest => dest, src => src);
        }
    }
}
