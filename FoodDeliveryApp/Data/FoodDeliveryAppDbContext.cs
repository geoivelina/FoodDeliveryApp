﻿using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Infrastructures;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Data
{
    public class FoodDeliveryAppDbContext : IdentityDbContext
    {
        public FoodDeliveryAppDbContext(DbContextOptions<FoodDeliveryAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CuisineType> CuisineTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.
                Entity<Restaurant>()
                .HasOne(c => c.CuisineType)
                .WithMany(c => c.Restaurants)
                .HasForeignKey(r => r.CuisineTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Dish>()
                .HasOne(d => d.Menu)
                .WithMany(d => d.Dishes)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Invoice>()
                .HasOne(i => i.Address)
                .WithMany(a => a.Invoices)
                .HasForeignKey(i => i.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Invoice>()
            //    .HasOne(i => i.Order)
            //    .WithMany(o => o.Invoices)
            //    .HasForeignKey(i => i.OrderId)
            //    .OnDelete(DeleteBehavior.Restrict);


            builder.ApplyConfiguration<Restaurant>(new RestaurantConfiguration());
            builder.ApplyConfiguration<CuisineType>(new CuisineTypesConfiguration());
            builder.ApplyConfiguration<Menu>(new MenuConfiguration());
            base.OnModelCreating(builder);
        }
    }
}