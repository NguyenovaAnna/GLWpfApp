using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class EmployeeContactMethod
    {
        //public int Id { get; set; }
        
        public int EmployeeNumber { get; set; }
        public Employee Employee { get; set; }
        public int ContactMethodId { get; set; }
        public ContactMethod ContactMethod { get; set; }
        public string ContactMethodValue { get; set; }
        public bool IsSelected { get; set; }
    }
}
