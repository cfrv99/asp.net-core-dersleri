using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.Models
{
    public class EShopDbContext : IdentityDbContext<AppUser>
    {
        public EShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(t => new { t.OrderId, t.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(pt => pt.Order)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(pt => pt.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(pt => pt.Product)
                .WithMany(t => t.OrderProducts)
                .HasForeignKey(pt => pt.ProductId);


            modelBuilder.Entity<ProductTag>()
                .HasKey(t => new { t.TagId, t.ProductId });

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.ProductId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

    }
}
