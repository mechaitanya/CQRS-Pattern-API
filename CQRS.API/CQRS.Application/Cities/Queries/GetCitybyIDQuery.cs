using CQRS.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Cities.Queries
{
    public class GetCitybyIDQuery : IRequest<CityDto>
    {
        public int id { get; set; }
    }
}
