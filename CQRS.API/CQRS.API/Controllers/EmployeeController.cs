using CQRS.Application.Dto;
using CQRS.Application.Employee.Commands;
using CQRS.Application.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<EmployeeDto>> GetEmployeeList(CancellationToken cancellation)
        {
            return await mediator.Send(new GetAllEmployees(), cancellation);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<List<EmployeeDto>> GetEmployeeByID(int id, CancellationToken cancellation)
        {
            return await mediator.Send(new GetEmployeeDetails { EmpID = id }, cancellation);
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<bool> Post([FromBody] EmployeeDto employee, CancellationToken token)
        {
            return await mediator.Send(new CreateEmployeeCommand { EmpDto = employee}, token);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{empID}")]
        public async Task<bool> Delete(int empID, CancellationToken cancellation)
        {
            return await mediator.Send(new DeleteEmployeeCommand { EmpID = empID }, cancellation);
        }

        // PUT api/<CityController>/5
        [HttpPut("{EmpID}")]
        public async Task<bool> Update(int EmpID, [FromBody] EmployeeDto employeeDto, CancellationToken cancellation)
        {
            return await mediator.Send(new UpdateEmployeeCommand { 
            EmpID = EmpID,
            employeeDto = employeeDto
            }, cancellation);;
        }
    }
}
