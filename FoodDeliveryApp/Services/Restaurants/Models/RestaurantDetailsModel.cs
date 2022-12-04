using FoodDeliveryApp.Services.Dishes;
using FoodDeliveryApp.Services.Menus;

namespace FoodDeliveryApp.Services.Restaurants.Models
{
    public class RestaurantDetailsModel : RestaurantServiceModel
    {
        public IEnumerable<MenusServiceModels> Menus { get; set; } = new List<MenusServiceModels>();
        public IEnumerable<DishesServiceModel> Dishes { get; set; } = new List<DishesServiceModel>();


    }
}
