using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFavoriteUser> ProductFavoriteUsers { get; set; }


      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(); // Habilitar Lazy Loading
        }*/
    }

}
