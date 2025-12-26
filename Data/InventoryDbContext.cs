using Microsoft.EntityFrameworkCore;
using InventoryManagement.API.Models;

namespace InventoryManagement.API.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed initial data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics" },
                new Category { CategoryId = 2, CategoryName = "Clothing" },
                new Category { CategoryId = 3, CategoryName = "Books" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Laptop", Quantity = 10, Price = 999.99m, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "T-Shirt", Quantity = 50, Price = 19.99m, CategoryId = 2 },
                new Product { ProductId = 3, ProductName = "Programming Book", Quantity = 30, Price = 49.99m, CategoryId = 3 }
            );
        }
    }
}
