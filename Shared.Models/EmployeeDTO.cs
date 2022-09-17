using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class EmployeeDTO
    {
        public int EmployeeNumber { get; set; }
        public int NationalIdNumber { get; set; }
        public int PreviousIdNumber { get; set; }
        public int PersonellNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime ActivationTime { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
