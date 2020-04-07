using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(b => b.Barcode)
                .IsUnique();
            modelBuilder.Entity<Product>()
                .Property(b => b.Barcode)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(b => b.Name)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(b => b.Price)
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(b => b.InvoiceNumber)
                .IsRequired();
            modelBuilder.Entity<AppUser>()
                .Property(b => b.Ein)
                .IsRequired();
            modelBuilder.Entity<AppUser>()
                .Property(b => b.CompanyName)
                .IsRequired();
            modelBuilder.Entity<Category>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey("CategoryId")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne(p => p.User)
                .WithMany(c => c.Orders)
                .HasForeignKey("UserId")
                .IsRequired();

            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(p => p.Order)
                .WithMany(c => c.ProductOrders)
                .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(p => p.Product)
                .WithMany(c => c.ProductOrders)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<CartItem>()
                .HasOne(p => p.User)
                .WithMany(c => c.CartItems)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            modelBuilder.Entity<CartItem>()
                .HasOne(p => p.Product)
                .WithMany(c => c.CartItems)
                .HasForeignKey(p => p.ProductId)
                .IsRequired();
        }
    }
}
