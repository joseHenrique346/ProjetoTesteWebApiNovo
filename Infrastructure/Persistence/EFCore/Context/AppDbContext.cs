using Infrastructure.Persistence.EFCore.Entity.Registration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFCore.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CustomerAddress> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Brand).Assembly);
        }
    }
}