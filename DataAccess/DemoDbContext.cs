using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DemoDbContext:DbContext
    {
        public DemoDbContext()
        {

        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options):base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
    }
}
