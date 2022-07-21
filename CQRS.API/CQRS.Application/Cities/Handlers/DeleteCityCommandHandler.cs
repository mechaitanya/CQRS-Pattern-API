using CQRS.Application.Cities.Commands;
using CQRS.Application.Dto;
using CQRS.Application.Interfaces;
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
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, bool>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public DeleteCityCommandHandler(IApplicationDbContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }

        public async Task<bool> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = context.cities.FirstOrDefault(x => x.ID == request.ID);
            if (city != null)
                context.cities.Remove(city);
            await context.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
    }
}
