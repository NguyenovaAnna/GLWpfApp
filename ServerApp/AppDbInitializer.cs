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
                    });

                    context.SaveChanges();
                }
                if (!context.ContactMethod.Any())
                {
                    context.ContactMethod.AddRange(new ContactMethod()
                    {
                        ContactMethodType = "Email"
                    },
                    new ContactMethod()
                    {
                        ContactMethodType = "Phone Number"
                    },
                    new ContactMethod()
                    {
                        ContactMethodType = "Skype"
                    },
                    new ContactMethod()
                    {
                        ContactMethodType = "Linkedin"

                    });

                    context.SaveChanges();
                }
                if (!context.EmployeeContactMethod.Any())
                {
                    context.EmployeeContactMethod.AddRange(new EmployeeContactMethod()
                    {
                        EmployeeNumber = 1,
                        ContactMethodId = 1,
                        ContactMethodValue = "anna@email.com"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 1,
                        ContactMethodId = 2,
                        ContactMethodValue = "+421 911 111 111"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 1,
                        ContactMethodId = 3,
                        ContactMethodValue = "anna111"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 2,
                        ContactMethodId = 1,
                        ContactMethodValue = "daniela@email.com"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 2,
                        ContactMethodId = 2,
                        ContactMethodValue = "+421 911 222 222"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 3,
                        ContactMethodId = 2,
                        ContactMethodValue = "+421 911 333 333"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 3,
                        ContactMethodId = 3,
                        ContactMethodValue = "dominika333"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 4,
                        ContactMethodId = 2,
                        ContactMethodValue = "+421 911 444 444"
                    },
                    new EmployeeContactMethod()
                    {
                        EmployeeNumber = 5,
                        ContactMethodId = 1,
                        ContactMethodValue = "peter@email.com"
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
