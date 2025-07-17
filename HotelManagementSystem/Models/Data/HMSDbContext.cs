using HotelManagementSystem.Models.Common;
using HotelManagementSystem.Models.ModelClasses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelManagementSystem.Models.Data
{
    public class HMSDbContext : DbContext
    {
        public HMSDbContext(DbContextOptions<HMSDbContext> options) : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<BaseEntity>();

            modelBuilder.Entity<Table>()
        .HasMany(t => t.Orders)
        .WithOne(o => o.Table)
        .HasForeignKey(o => o.TableId)
        .OnDelete(DeleteBehavior.Cascade);

            // Order -> OrderItem
            modelBuilder.Entity<Order>()
                .HasMany(o => o.items)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // OrderItem -> MenuItem
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany() // Assuming MenuItem does NOT have List<OrderItem>
                .HasForeignKey(oi => oi.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict); // Optional: prevent cascade delete

            //modelBuilder.Entity<BaseEntity>()
            //    .Property(b => b.CreatedDate)
            //    .HasDefaultValueSql("GETDATE()");

        }

    }
}
