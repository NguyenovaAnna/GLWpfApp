using Microsoft.AspNetCore.Mvc;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        List<EmployeeDTO> employees = new List<EmployeeDTO>();

        public EmployeesController()
        {
            employees.Add(new EmployeeDTO
            {
                FirstName = "Anna",
                LastName = "Nguyenova",
                EmployeeNumber = 1,
                MiddleName = string.Empty,
                NationalIdNumber = 1,
                PreviousIdNumber = 0,
                PersonellNumber = 11,
                ActivationTime = new DateTime(2020, 1, 1),
                ExpirationTime = new DateTime(2025, 12, 31),
                ContactMethod = new List<ContactMethodDTO>()
                {
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 111 111" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "anna@email.com" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "anna111" }
                }
            });
            employees.Add(new EmployeeDTO
            {
                FirstName = "Daniela",
                LastName = "Horvathova",
                EmployeeNumber = 2, 
                MiddleName = string.Empty,
                NationalIdNumber = 2, 
                PreviousIdNumber = 0,
                PersonellNumber = 22,
                ActivationTime = new DateTime(2020, 1, 1),
                ExpirationTime = new DateTime(2025, 12, 31),
                ContactMethod = new List<ContactMethodDTO>()
                {
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 222 222" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "daniela@email.com" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "daniela222" }
                }
            });
            employees.Add(new EmployeeDTO
            {
                FirstName = "Dominika",
                LastName = "Mala",
                EmployeeNumber = 3,
                MiddleName = string.Empty,
                NationalIdNumber = 3,
                PreviousIdNumber = 0, 
                PersonellNumber = 33,
                ActivationTime = new DateTime(2020, 1, 1),
                ExpirationTime = new DateTime(2025, 12, 31),
                ContactMethod = new List<ContactMethodDTO>()
                {
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 333 333" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "dominika@email.com" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "dominika333" }
                }
            });
            employees.Add(new EmployeeDTO
            {
                FirstName = "David",
                LastName = "Kovac",
                EmployeeNumber = 4,
                MiddleName = string.Empty,
                NationalIdNumber = 4,
                PreviousIdNumber = 0,
                PersonellNumber = 44,
                ActivationTime = new DateTime(2020, 1, 1),
                ExpirationTime = new DateTime(2025, 12, 31),
                ContactMethod = new List<ContactMethodDTO>()
                {
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 444 444" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "david@email.com" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "david444" }
                }
            });
            employees.Add(new EmployeeDTO
            {
                FirstName = "Peter",
                LastName = "Duris",
                EmployeeNumber = 5,
                MiddleName = string.Empty,
                NationalIdNumber = 5,
                PreviousIdNumber = 0,
                PersonellNumber = 55,
                ActivationTime = new DateTime(2020, 1, 1),
                ExpirationTime = new DateTime(2025, 12, 31),
                ContactMethod = new List<ContactMethodDTO>()
                {
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 555 555" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "peter@email.com" },
                    new ContactMethodDTO { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "peter555" }
                }
            });
        }
        
        // GET: api/employees
        [HttpGet]
        public List<EmployeeDTO> Get()
        {
            return employees;
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public EmployeeDTO Get(int id)
        {
            return employees.Where(x => x.EmployeeNumber == id).FirstOrDefault();
        }

        // POST api/employees
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
