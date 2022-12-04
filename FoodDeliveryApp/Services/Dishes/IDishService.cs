using FoodDeliveryApp.Models.Restaurant;
using FoodDeliveryApp.Services.Menus;
using FoodDeliveryApp.Services.Restaurants.Models;

namespace FoodDeliveryApp.Services.Dishes
{
    public interface IDishService
    {
        int Create(string name,
                string descriprion,
                string dishImage,
                decimal price,
                int menuId,
                int restaurantId);
        bool MenuExist(int menuId);

       // IEnumerable<DishesServiceModel> GetAllDishes(int menuId, int restaurantId);

        bool RestaurantExist(int restaurantId);
        IEnumerable<RestaurantServiceModel> GetAllRestaurants();
        IEnumerable<MenusServiceModels> AllMenus(int restaurantId);
    }

}
