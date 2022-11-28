using FoodDeliveryApp.Data.Entities;
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

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<CuisineType> CuisineTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.
                Entity<Restaurant>()
                .HasOne(c => c.CuisineType)
                .WithMany(c => c.Restaurants)
                .HasForeignKey(r => r.CuisineTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ApplyConfiguration<Restaurant>(new RestaurantConfiguration());
            builder.ApplyConfiguration<CuisineType>(new CuisineTypesConfiguration());
            base.OnModelCreating(builder);
        }
    }
}