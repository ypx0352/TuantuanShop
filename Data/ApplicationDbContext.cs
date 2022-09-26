using Microsoft.EntityFrameworkCore;
using TuantuanShop.Models;

namespace TuantuanShop.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Banner> Banner { get; set; }
    }
}
