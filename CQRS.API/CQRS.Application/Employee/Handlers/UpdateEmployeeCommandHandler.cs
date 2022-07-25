using CQRS.Application.Employee.Commands;
using CQRS.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Employee.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public UpdateEmployeeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = applicationDbContext.Employee.FirstOrDefault(x => x.EmpID == request.EmpID);
            var empDetails = applicationDbContext.EmployeeDetails.FirstOrDefault(x => x.EmpID == request.EmpID);
            if (empDetails != null && emp != null)
            {
                emp.FirstName = request.employeeDto.FirstName;
                emp.LastName = request.employeeDto.LastName;
                empDetails.EmpAge = request.employeeDto.EmpAge;
                empDetails.Gender = request.employeeDto.Gender;
                empDetails.DOB = request.employeeDto.DOB;
            }
            applicationDbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
