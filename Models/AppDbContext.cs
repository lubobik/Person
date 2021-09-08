using Microsoft.EntityFrameworkCore;
using Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class AppDbContext :DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
