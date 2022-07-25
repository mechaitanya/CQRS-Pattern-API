using CQRS.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Employee.Queries
{
    public class GetEmployeeDetails : IRequest<List<EmployeeDto>>
    {
        public int EmpID { get; set; }
    }
}
