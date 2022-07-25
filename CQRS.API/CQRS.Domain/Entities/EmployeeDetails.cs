using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.Entities
{
    public class EmployeeDetails
    {
        [Key]
        public int ID { get; set; }
        public int EmpID { get; set; }
        public int EmpAge { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}
