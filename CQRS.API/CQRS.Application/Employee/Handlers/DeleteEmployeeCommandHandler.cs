using CQRS.Application.Employee.Commands;
using CQRS.Application.Interfaces;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Employee.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public DeleteEmployeeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = applicationDbContext.Employee.FirstOrDefault(x => x.EmpID == request.EmpID);
            var empDetails = applicationDbContext.EmployeeDetails.FirstOrDefault(x => x.EmpID == request.EmpID);
            if (emp != null && empDetails != null)
            {
                applicationDbContext.Employee.Remove(emp);
                applicationDbContext.EmployeeDetails.Remove(empDetails);
            }
            applicationDbContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}
