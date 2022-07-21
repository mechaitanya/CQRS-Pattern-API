using CQRS.Application.Cities.Commands;
using CQRS.Application.Dto;
using CQRS.Application.Interfaces;
using CQRS.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Cities.Handlers
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CityDto>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public CreateCityCommandHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }

        public Task<CityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var obj = new City
            {
                ID = request.ID,
                Name = request.Name,
                State = request.State
            };
            context.cities.Add(obj);
            context.SaveChanges();

            //CityDto city = new CityDto { State = obj.State, Name = obj.Name };
            return Task.FromResult(mapper.Map<CityDto>(obj));
        }
    }
}
