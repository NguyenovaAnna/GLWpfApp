using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ContactMethod
    {
        public int ContactMethodId { get; set; }
        public bool IsSelected { get; set; }
        public string ContactMethodType { get; set; }
        public string ContactMethodValue { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ContactMethod()
        {
            Employees = new List<Employee>();
        }

        //public ICollection<EmployeeContactMethod> EmployeeContactMethods { get; set; }

    }
}
