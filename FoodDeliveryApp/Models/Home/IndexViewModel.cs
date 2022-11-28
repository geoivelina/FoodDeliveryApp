namespace FoodDeliveryApp.Models.Home
{
    public class IndexViewModel
    {
        public int TotalRestaurants { get; set; }
        public int TotalUsers { get; set; }
        public int TotalOrders { get; set; }
        public List<RestaurantIndexModel> Restaurants { get; set; }
    }
}
