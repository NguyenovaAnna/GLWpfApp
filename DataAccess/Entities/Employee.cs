using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Employee
    {
        
        [Key]
        public int EmployeeNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public int NationalIdNumber { get; set; }
        public int PreviousIdNumber { get; set; }
        public int PersonellNumber { get; set; }
        public DateTime ActivationTime { get; set; }
        public DateTime? ExpirationTime { get; set; }

        public ICollection<ContactMethod> ContactMethods { get; set; }
        //public ICollection<EmployeeContactMethod> EmployeeContactMethods { get; set; }

        public Employee()
        {
            ContactMethods = new List<ContactMethod>();
        }

    }
}
