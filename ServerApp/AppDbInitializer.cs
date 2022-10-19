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
                        ContactMethods = new List<ContactMethod>()

                        {
                            new ContactMethod { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 111 111" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "anna@email.com" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "anna111" }
                        }
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
                        ContactMethods = new List<ContactMethod>()

                        {
                            new ContactMethod { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 222 222" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "daniela@email.com" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "daniela222" }
                        }
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
                        ContactMethods = new List<ContactMethod>()

                        {
                            new ContactMethod { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 333 333" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "dominika@email.com" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "dominika333" }
                        }
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
                        ContactMethods = new List<ContactMethod>()

                        {
                            new ContactMethod { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 444 444" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "david@email.com" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "david444" }
                        }
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
                        ContactMethods = new List<ContactMethod>()

                        {
                            new ContactMethod { IsSelected = true, ContactMethodType = "PhoneNumber", ContactMethodValue = "+421 911 555 555" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Email", ContactMethodValue = "peter@email.com" },
                            new ContactMethod { IsSelected = true, ContactMethodType = "Skype", ContactMethodValue = "peter555" }
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
