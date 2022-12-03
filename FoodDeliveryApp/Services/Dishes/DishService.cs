
using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Models.Dish;

namespace FoodDeliveryApp.Services.Dishes
{
    public class DishService : IDishService
    {
        private readonly FoodDeliveryAppDbContext data;

        public DishService(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }

        public int Create(string name, string descriprion, string dishImage, decimal price, int menuId, int restaurantId)
        {
            var dishModel = new Dish
            {
                Name = name,
                Descriprion = descriprion,
                DishImage = dishImage,
                Price = price,
                MenuId = menuId,
                RestaurantId = restaurantId
            };

            this.data.Dishes.Add(dishModel);
            this.data.SaveChanges();

            return dishModel.Id;
        }

        public bool MenuExist(int menuId)
        {
            return this.data.Menus.Any(m => m.Id == menuId);
        }

        public IEnumerable<RestaurantMenuModel> GetAllMenues()
        {
            return this.data
                .Menus
                .Select(m => new RestaurantMenuModel()
                {
                    Id = m.Id,
                    Name = m.Name
                });
        }

        public IEnumerable<RestaurantServiceModel> GetAllRestaurants()
        {
            return this.data.Restaurants
                 .Select(r => new RestaurantServiceModel
                 {
                     Id = r.Id,
                     Name = r.Name,
                 })
                 .ToList();
        }

        public bool RestaurantExist(int restaurantId)
        {
            return this.data.Restaurants.Any(r => r.Id == restaurantId);
        }
    }
}
