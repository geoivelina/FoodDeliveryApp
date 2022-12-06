using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Infrastructures;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Data
{
    public class FoodDeliveryAppDbContext : IdentityDbContext<User>
    {
        public FoodDeliveryAppDbContext(DbContextOptions<FoodDeliveryAppDbContext> options)
            : base(options)
        {
            //this.Database.Migrate();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CuisineType> CuisineTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
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

           

            //builder
            //    .Entity<Dish>()
            //    .HasOne(d => d.Menu)
            //    .WithMany(d => d.Dishes)
            //    .HasForeignKey(d => d.MenuId)
            //    .OnDelete(DeleteBehavior.Restrict);


            

            builder.ApplyConfiguration<Restaurant>(new RestaurantConfiguration());
            builder.ApplyConfiguration<CuisineType>(new CuisineTypesConfiguration());
            builder.ApplyConfiguration<Menu>(new MenuConfiguration());
            //builder.ApplyConfiguration<Dish>(new DishesConfiguration());
            base.OnModelCreating(builder);
        }
    }
}