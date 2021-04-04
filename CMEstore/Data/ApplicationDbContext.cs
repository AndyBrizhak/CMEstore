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
        public DbSet<Product> Product { get; set; }
    }
}
