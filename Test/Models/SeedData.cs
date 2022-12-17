using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace Test.Models
{
    /// <summary>
    /// Для подключения базы данных
    /// </summary>
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TestContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TestContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }
                context.Users.AddRange(
                    new User
                    {
                        Name = "Lev",
                        Is_Admin = true,
                        Mail = "ivan-shashlik@mail.ru",
                        Password = "Pass",
                        Department_id = 1,
                        Access_id = 1,
                        Date_of_birth = DateTime.Parse("2001-23-1"),
                        Can_access_private = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
