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
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<CityDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper mapper;

        public GetCitiesQueryHandler(IApplicationDbContext applicationDbContext, IMapper Mapper)
        {
            _applicationDbContext = applicationDbContext;
             mapper = Mapper;
        }
        public Task<List<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            List<City> city = _applicationDbContext.Cities.Select(x => new City
            {
                ID= x.ID,
                Name= x.Name,
                State= x.State
            }).ToList();
            return Task.FromResult(mapper.Map<List<CityDto>>(city));
        }
    }
}
