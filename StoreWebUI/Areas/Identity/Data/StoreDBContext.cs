using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lateu_Richard_P1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace Lateu_Richard_P1.Data
{
    public class StoreDBContext : IdentityDbContext<ApplicationUser>
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Customer>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Inventory>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<OrderItem>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Location>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<InventoryItem>().Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
