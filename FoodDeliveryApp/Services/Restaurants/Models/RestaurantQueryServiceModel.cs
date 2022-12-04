namespace FoodDeliveryApp.Services.Restaurants.Models
{
    public class RestaurantQueryServiceModel
    {
        public int TotalRestaurants { get; set; }
        public int CurrentPage { get; set; }
        public int RestaurantsPerPage { get; set; }
        public List<RestaurantServiceModel> Restaurants { get; set; }
    }
}
