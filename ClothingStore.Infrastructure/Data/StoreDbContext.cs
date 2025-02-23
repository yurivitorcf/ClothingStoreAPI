using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.Infrastructure.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
