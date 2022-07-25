using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Dto
{
    public class EmployeeDto
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmpAge { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}
