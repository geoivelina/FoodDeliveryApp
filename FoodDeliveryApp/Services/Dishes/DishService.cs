
using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Models.Restaurant;
using FoodDeliveryApp.Services.Menus;
using FoodDeliveryApp.Services.Restaurants.Models;

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
        public IEnumerable<MenusServiceModels> AllMenus(int restaurantId)
        {
            return this.data
                .Menus
                .Where(m => m.RestaurantId == restaurantId)
                .Select(m => new MenusServiceModels
                {
                    Id = m.Id,
                    Name = m.Name
                })
            .ToList();
        }

        //public IEnumerable<DishesServiceModel> GetAllDishes(int menuId, int restaurantId)
        //{
        //    return this.data
        //        .Dishes
        //        .Where(d => d.MenuId == menuId && d.RestaurantId == restaurantId)
        //        .Select(d => new DishesServiceModel
        //        {
        //            Name = d.Name,
        //            Descriprion = d.Descriprion,
        //            DishImage  = d.DishImage,
        //            Price = d.Price
        //        })
        //        .ToList();
        //}
    }
}
