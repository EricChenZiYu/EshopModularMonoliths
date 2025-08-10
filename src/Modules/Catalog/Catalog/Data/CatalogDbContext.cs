using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.Data
{
    public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("catalog");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            // Configure your entities here
        }

        // Fix for CS0236: Initialize DbSet properties without using non-static methods
        public DbSet<Product> Products => Set<Product>();

    }
}
