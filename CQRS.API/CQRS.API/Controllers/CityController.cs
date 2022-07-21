using CQRS.Application.Cities.Commands;
using CQRS.Application.Cities.Handlers;
using CQRS.Application.Cities.Queries;
using CQRS.Application.Dto;
using CQRS.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public CityController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<List<CityDto>> GetAllCities(CancellationToken cancellation)
        {
            return await _mediatr.Send(new GetCitiesQuery(), cancellation);
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<CityDto> GetCitybyID(int id, CancellationToken cancellation)
        {
            return await _mediatr.Send(new GetCitybyIDQuery { id = id }, cancellation);
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<CityDto> Post([FromBody] CityDto city, CancellationToken token)
        {
            return await _mediatr.Send(new CreateCityCommand(city), token);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id, CancellationToken cancellation)
        {
            return await _mediatr.Send(new DeleteCityCommand { ID = id }, cancellation);
        }
    }
}
