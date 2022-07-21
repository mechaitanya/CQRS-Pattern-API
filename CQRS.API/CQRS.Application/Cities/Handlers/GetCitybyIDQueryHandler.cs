using CQRS.Application.Cities.Queries;
using CQRS.Application.Dto;
using CQRS.Application.Interfaces;
using CQRS.Domain.Entities;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Cities.Handlers
{
    public class GetCitybyIDQueryHandler : IRequestHandler<GetCitybyIDQuery, CityDto>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetCitybyIDQueryHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }

        public Task<CityDto> Handle(GetCitybyIDQuery request, CancellationToken cancellationToken)
        {
            City city = context.cities.FirstOrDefault(x => x.ID == request.id);
            return Task.FromResult(mapper.Map<CityDto>(city));
        }
    }
}
