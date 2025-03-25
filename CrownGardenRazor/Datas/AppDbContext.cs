using CrownGardenRazor.Model;
using Microsoft.EntityFrameworkCore;

namespace CrownGardenRazor.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
