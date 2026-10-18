using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasOne(a => a.Category)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
               .HasOne(a => a.User)
               .WithMany(a => a.Orders)
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
               .HasOne(a => a.Order)
               .WithMany(a => a.OrderItems)
               .HasForeignKey(a => a.OrderId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
               .HasOne(a => a.Product)
               .WithMany(a => a.OrderItems)
               .HasForeignKey(a => a.ProductId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>().HasKey(s => new { s.ProductId, s.OrderId });

            modelBuilder.Entity<User>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(a => a.CategoryName).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
