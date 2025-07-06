using HotelManagementSystem.Models.Common;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<BaseEntity>();

            modelBuilder.Entity<Table>()
                .HasMany(t => t.Orders)
                .WithOne(o => o.Table)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<BaseEntity>()
            //    .Property(b => b.CreatedDate)
            //    .HasDefaultValueSql("GETDATE()");

        }

    }
}
