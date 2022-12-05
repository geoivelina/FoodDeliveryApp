using FoodDeliveryApp.Models.Restaurant;
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
        bool RestaurantExist(int restaurantId);

       // IEnumerable<DishesServiceModel> GetAllDishesByMenuId(int menuId, int restaurantId);

        IEnumerable<DishRestaurantServiceModel> GetAllRestaurants();
        IEnumerable<DishMenusServiceModels> GetAllMenus();

       // IEnumerable<DishMenusServiceModels> GetAllMenusByRestaurantId(int restaurantId);
    }

}
