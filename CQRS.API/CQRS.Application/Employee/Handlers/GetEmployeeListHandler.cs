using CQRS.Application.Dto;
using CQRS.Application.Employee.Queries;
using CQRS.Application.Interfaces;
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
    public class GetEmployeeListHandler : IRequestHandler<GetAllEmployees, List<EmployeeDto>>
    {
        private readonly IApplicationDbContext applicationDbContext;

        public GetEmployeeListHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
        {
            var result = await applicationDbContext.QueryResult.FromSqlRaw("Execute dbo.GetEmployeeData").ToListAsync(cancellationToken: cancellationToken);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmployeeDto>>(result[0].JsonResult);
            return data?.Count > 0 ? data : new List<EmployeeDto>();
        }
    }
}
