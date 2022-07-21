using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Interfaces
{
    public interface IApplicationDbContext 
    {
       public DbSet<City> cities { get; set; }
       int SaveChanges();
       Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
