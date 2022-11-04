using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ContactMethodDTO
    {
        public int ContactMethodId { get; set; }
        
        public string ContactMethodType { get; set; }

        public string ContactMethodValue { get; set; }

        //public ICollection<EmployeeContactMethodDTO> Employees { get; set; }

        //public ContactMethodDTO()
        //{
        //    Employees = new List<EmployeeContactMethodDTO>();
        //}

    }
}
