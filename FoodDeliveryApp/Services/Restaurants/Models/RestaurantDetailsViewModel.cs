using FoodDeliveryApp.Services.Dishes;
using FoodDeliveryApp.Services.Menus;

namespace FoodDeliveryApp.Services.Restaurants.Models
{
    public class RestaurantDetailsViewModel : RestaurantServiceModel
    {
        public int CuisineTypeId { get; set; }
        public IEnumerable<RestaurantMenuModel> Menus { get; set; } = new List<RestaurantMenuModel>();
        public IEnumerable<DishesServiceModel> Dishes { get; set; } = new List<DishesServiceModel>();


    }
}
