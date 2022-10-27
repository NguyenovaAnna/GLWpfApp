using DataAccess.Context;
using DataAccess.Entities;

namespace ServerApp
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EmployeesContext>();
                if (!context.Employee.Any())
                {
                    context.Employee.AddRange(new Employee()
                    {
                        FirstName = "Anna",
                        LastName = "Nguyenova",
                        MiddleName = string.Empty,
                        NationalIdNumber = 1,
                        PreviousIdNumber = 0,
                        PersonellNumber = 11,
                        ActivationTime = new DateTime(2020, 1, 1),
                        ExpirationTime = new DateTime(2025, 12, 31),
                        //ContactMethods = new List<EmployeeContactMethod>()
                        //{
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 1, ContactMethodValue = "+421 911 111 111"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 2, ContactMethodValue = "anna@email.com"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 3, ContactMethodValue = "anna111"}
                        //}
                    },
                    new Employee()
                    {
                        FirstName = "Daniela",
                        LastName = "Horvathova",
                        MiddleName = string.Empty,
                        NationalIdNumber = 2,
                        PreviousIdNumber = 0,
                        PersonellNumber = 22,
                        ActivationTime = new DateTime(2020, 1, 1),
                        ExpirationTime = new DateTime(2025, 12, 31),
                        //ContactMethods = new List<EmployeeContactMethod>()
                        //{
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 1, ContactMethodValue = "+421 911 222 222"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 2, ContactMethodValue = "daniela@email.com"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 3, ContactMethodValue = "daniela222"}
                        //}
                    },
                    new Employee()
                    {
                        FirstName = "Dominika",
                        LastName = "Mala",
                        MiddleName = string.Empty,
                        NationalIdNumber = 3,
                        PreviousIdNumber = 0,
                        PersonellNumber = 33,
                        ActivationTime = new DateTime(2020, 1, 1),
                        ExpirationTime = new DateTime(2025, 12, 31),
                        //ContactMethods = new List<EmployeeContactMethod>()
                        //{
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 1, ContactMethodValue = "+421 911 333 333"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 2, ContactMethodValue = "dominika@email.com"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 3, ContactMethodValue = "dominika333"}
                        //}
                    },
                    new Employee()
                    {
                        FirstName = "David",
                        LastName = "Kovac",
                        MiddleName = string.Empty,
                        NationalIdNumber = 4,
                        PreviousIdNumber = 0,
                        PersonellNumber = 44,
                        ActivationTime = new DateTime(2020, 1, 1),
                        ExpirationTime = new DateTime(2025, 12, 31),
                        //ContactMethods = new List<EmployeeContactMethod>()
                        //{
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 1, ContactMethodValue = "+421 911 444 444"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 2, ContactMethodValue = "david@email.com"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 3, ContactMethodValue = "david444"}
                        //}
                    },
                    new Employee()
                    {
                        FirstName = "Peter",
                        LastName = "Duris",
                        MiddleName = string.Empty,
                        NationalIdNumber = 5,
                        PreviousIdNumber = 0,
                        PersonellNumber = 55,
                        ActivationTime = new DateTime(2020, 1, 1),
                        ExpirationTime = new DateTime(2025, 12, 31),
                        //ContactMethods = new List<EmployeeContactMethod>()
                        //{
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 1, ContactMethodValue = "+421 911 555 555"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 2, ContactMethodValue = "peter@email.com"},
                        //    new EmployeeContactMethod {IsSelected = true, ContactMethodId = 3, ContactMethodValue = "peter555"}
                        //}
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
