using FoodDeliveryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructures
{
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasData(CreateMenus());
        }

        private List<Menu> CreateMenus()
        {
            var menus = new List<Menu>();

            var menu = new Menu()
            {
                Id = 1,
                Name = "Salads",
                RestaurantId = 1,
                
            };

            menus.Add(menu);
            menu = new Menu()
            {
                Id = 2,
                Name = "Cold appetizers",
                RestaurantId = 1,
                
            };

            menus.Add(menu); 

            menu = new Menu()
            {
                Id = 3,
                Name = "Pizza",
                RestaurantId = 1,
                
            };

       
            menus.Add(menu);

            menu = new Menu()
            {
                Id = 4,
                Name = "Salads",
                RestaurantId = 2,
                
            };

            menus.Add(menu);
            menu = new Menu()
            {
                Id = 5,
                Name = "Starters",
                RestaurantId = 2,
                
            };

            menus.Add(menu);

            menu = new Menu()
            {
                Id = 6,
                Name = "Tandoori",
                RestaurantId = 2,
                
            };


            menu = new Menu()
            {
                Id = 7,
                Name = "The boxes",
                RestaurantId = 3,
                
            };

            menus.Add(menu);
            menu = new Menu()
            {
                Id = 8,
                Name = "Burgers",
                RestaurantId = 3,
               
            };

            menus.Add(menu);


            menu = new Menu()
            {
                Id = 9,
                Name = "Nigiri",
                RestaurantId = 5,
                
            };

            menus.Add(menu);
            menu = new Menu()
            {
                Id = 10,
                Name = "Hosomaki",
                RestaurantId = 5,
             
            };

            menus.Add(menu);

            menu = new Menu()
            {
                Id = 11,
                Name = "Uramaki",
                RestaurantId = 5,
                
            };

            menus.Add(menu);

            return menus;
        }
    }
}
