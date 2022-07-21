using CQRS.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Cities.Commands
{
    public class DeleteCityCommand : IRequest<bool>
    {
        public int ID { get; set; }
    }
}
