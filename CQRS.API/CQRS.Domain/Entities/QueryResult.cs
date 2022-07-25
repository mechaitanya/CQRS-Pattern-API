using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.Entities
{
    [NotMapped]
    [Keyless]
    public class QueryResult
    {
        public string JsonResult { get; set; }
    }
}
