using CQRS.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Employee.Commands
{
    public class CreateEmployeeCommand : IRequest<bool>
    {
        public EmployeeDto EmpDto { get; set; }
    }
}
