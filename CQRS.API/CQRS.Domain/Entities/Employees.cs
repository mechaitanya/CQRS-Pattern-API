using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.Entities
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
