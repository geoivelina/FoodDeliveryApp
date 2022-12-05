

namespace FoodDeliveryApp.Services.Menus
{
    public interface IMenuService
    {
        int Create(string name, int restaurantId);
        IEnumerable<MenuRestaurantServiceModel> GetAllRestaurants();
        bool RestaurantExist(int restaurantId);

    }
}
