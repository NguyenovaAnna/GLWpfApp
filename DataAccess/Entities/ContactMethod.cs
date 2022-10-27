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
        [Key]
        public int ContactMethodId { get; set; }
        public string ContactMethodType { get; set; }
        public virtual ICollection<EmployeeContactMethod> Employees { get; set; }
    }
}
