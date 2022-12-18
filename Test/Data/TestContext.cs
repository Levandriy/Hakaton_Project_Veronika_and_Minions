using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test;
using Test.Models;

namespace Test.Data
{
    public class TestContext : DbContext
    {
        public TestContext (DbContextOptions<TestContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Job> Jobs { get; set; } = default!;
        public DbSet<Access_cons> Access_Cons { get; set; } = default!;
        public DbSet<Catalogs> Catalogs { get; set; } = default!;
        public DbSet<Catalog_cons> Catalog_Cons { get; set; } = default!;
        public DbSet<Materials> Materials { get; set; } = default!;
        public DbSet<Department> Departmets { get; set; } = default!;
    }
}
