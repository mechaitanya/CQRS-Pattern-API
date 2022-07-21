using CQRS.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Cities.Commands
{
    public class CreateCityCommand : IRequest<CityDto>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public CreateCityCommand(CityDto city)
        {
            ID = city.ID; ;
            Name = city.Name;
            State = city.State;
        }
    }
}
