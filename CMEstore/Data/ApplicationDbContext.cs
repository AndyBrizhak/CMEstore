using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMEstore.Models;
using Microsoft.EntityFrameworkCore;

namespace CMEstore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Brand> Brand { get; set; }
    }
}
