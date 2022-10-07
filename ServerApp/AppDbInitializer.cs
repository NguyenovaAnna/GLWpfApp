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
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new Employee()
                    {
                        FirstName = "Anna",
                        LastName = "Nguyenova",
                        MiddleName = string.Empty,
                        NationalIdNumber = 1,
                        PreviousIdNumber = 0,
                        PersonellNumber = 11,
                        ActivationTime = new DateTime(2020, 1, 1),
                        ExpirationTime = new DateTime(2025, 12, 31)
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
                        ExpirationTime = new DateTime(2025, 12, 31)
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
                        ExpirationTime = new DateTime(2025, 12, 31)
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
                        ExpirationTime = new DateTime(2025, 12, 31)
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
                        ExpirationTime = new DateTime(2025, 12, 31)
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
