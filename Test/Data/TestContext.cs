using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test;

namespace Test.Data
{
    public class TestContext : DbContext
    {
        public TestContext (DbContextOptions<TestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Models.User> Users { get; set; } = default!;
        public DbSet<Models.Job> Jobs { get; set; } = default!;
        public DbSet<Models.Access_cons> Access_Cons { get; set; } = default!;
        public DbSet<Models.Catalogs> Catalogs { get; set; } = default!;
        public DbSet<Models.Catalog_cons> Catalogs_Cons { get; set; } = default!;
        public DbSet<Models.Materials> Materials { get; set; } = default!;
        public DbSet<Models.Department> Departments { get; set; } = default!;
    }
}
