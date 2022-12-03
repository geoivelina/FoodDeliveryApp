using FoodDeliveryApp.Models.Dish;

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

        IEnumerable<RestaurantMenuModel> GetAllMenues();

        bool RestaurantExist(int restaurantId);
        IEnumerable<RestaurantServiceModel> GetAllRestaurants();
    }

}
