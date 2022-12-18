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
                serviceProvider.GetRequiredService<DbContextOptions<TestContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.AddRange(
                    new User
                    {
                        Name = "Lev",
                        Is_Admin = true,
                        Mail = "ivan@mail.ru",
                        Password = "Pass",
                        Job_id = 1,
                        Date_of_birth = DateTime.Parse("2001-23-1"),
                        Can_access_private = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
