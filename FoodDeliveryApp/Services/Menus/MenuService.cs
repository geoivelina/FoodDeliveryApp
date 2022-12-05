using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Services.Restaurants.Models;

namespace FoodDeliveryApp.Services.Menus
{
    public class MenuService : IMenuService
    {
        private readonly FoodDeliveryAppDbContext data;

        public MenuService(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }

        public int Create(string name, int restaurantId)
        {
            var menuModel = new Menu
            {
                Name = name,
                RestaurantId = restaurantId
            };

            this.data.Menus.Add(menuModel);
            this.data.SaveChanges();

            return menuModel.Id;
        }

        public IEnumerable<MenuRestaurantServiceModel> GetAllRestaurants()
        {
            return this.data.Restaurants
                    .Select(r => new MenuRestaurantServiceModel
                    {
                        Id = r.Id,
                        Name = r.Name
                    })
                    .ToList();
        }

        public bool RestaurantExist(int restaurantId)
        {
            return this.data.Menus.Any(r => r.RestaurantId == restaurantId);
        }
    }
}
