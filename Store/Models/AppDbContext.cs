﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Store.Models
{
    /// <summary>
    /// Context for database, here is current state of tables in database.
    /// </summary>
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Good>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Storage>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<GoodOrder>()
                .HasKey(g => new { g.GoodId, g.OrderId });
            modelBuilder.Entity<GoodStorage>()
                .HasKey(g => new { g.GoodId, g.StorageId });

            modelBuilder.Entity<GoodOrder>()
                .HasOne(g => g.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(g => g.OrderId);
            modelBuilder.Entity<GoodOrder>()
                .HasOne(o => o.Good)
                .WithMany(g => g.Orders)
                .HasForeignKey(g => g.GoodId);

            modelBuilder.Entity<GoodStorage>()
                .HasOne(g => g.Storage)
                .WithMany(s => s.Products)
                .HasForeignKey(g => g.StorageId);
            modelBuilder.Entity<GoodStorage>()
                .HasOne(s => s.Good)
                .WithMany(g => g.Storages)
                .HasForeignKey(g => g.GoodId);
        }
    }
}