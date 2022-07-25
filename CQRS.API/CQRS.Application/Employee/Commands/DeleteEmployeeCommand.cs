using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Employee.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int EmpID { get; set; }
    }
}
