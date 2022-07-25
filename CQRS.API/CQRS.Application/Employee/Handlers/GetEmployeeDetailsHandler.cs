using CQRS.Application.Dto;
using CQRS.Application.Employee.Queries;
using CQRS.Application.Interfaces;
using CQRS.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Employee.Handlers
{
    public class GetEmployeeDetailsHandler : IRequestHandler<GetEmployeeDetails,List<EmployeeDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetEmployeeDetailsHandler(IApplicationDbContext applicationDbContext)    
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeeDetails request, CancellationToken cancellationToken)
        {
            var result = await _applicationDbContext.QueryResult.FromSqlRaw("Execute dbo.GetEmployeeData {0}", request.EmpID).ToListAsync(cancellationToken: cancellationToken);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmployeeDto>>(result[0].JsonResult);
            return data?.Count > 0  ?  data : new List<EmployeeDto>();
        }
    }
}
