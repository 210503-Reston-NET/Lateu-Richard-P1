using System;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class StoreDBContext:DbContext
    {
         public StoreDBContext() : base()
        {}
        public StoreDBContext(DbContextOptions options): base(options){

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<OrderItem> Items { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users{get;set;}
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderItem>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<InventoryItem>().Property(e => e.Id).ValueGeneratedOnAdd();

        }
    }
}