using CQRS.Application.Dto;
using CQRS.Application.Employee.Commands;
using CQRS.Application.Interfaces;
using CQRS.Domain.Entities;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Employee.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public CreateEmployeeCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }
        public Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = new Employees
            {
                EmpID = request.EmpDto.EmpID,
                FirstName = request.EmpDto.FirstName,
                LastName = request.EmpDto.LastName
            };

            var empDetails = new EmployeeDetails
            {
                EmpID = request.EmpDto.EmpID,
                EmpAge= request.EmpDto.EmpAge,
                DOB = request.EmpDto.DOB,
                Gender = request.EmpDto.Gender
            };

            applicationDbContext.Employee.Add(emp);
            applicationDbContext.EmployeeDetails.Add(empDetails);
            applicationDbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
