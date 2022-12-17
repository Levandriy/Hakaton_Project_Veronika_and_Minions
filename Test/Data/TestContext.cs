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
        }

        public DbSet<Test.User> User { get; set; } = default!;

        public DbSet<Test.Access> Access { get; set; } = default!;

        public DbSet<Test.Access_cons> Access_cons { get; set; } = default!;

        public DbSet<Test.Models.Catalogs> Catalogs { get; set; } = default!;

        public DbSet<Test.Models.Catalog_cons> Catalog_cons { get; set; } = default!;

        public DbSet<Test.Materials> Materials { get; set; } = default!;
    }
}
