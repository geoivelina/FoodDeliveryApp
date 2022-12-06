namespace FoodDeliveryApp.Services.Restaurants.Models
{
    public class RestaurantDeleteViewMOdel
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public string RestaurantImage { get; set; } = null!;

        public decimal Rating { get; set; }

        public string WorkingHours { get; set; } = null!;

        public string DeliveryCost { get; set; } = null!;

        public string MinOrderAmount { get; set; } = null!;

        public string DeliveryTime { get; set; } = null!;
        public string CuisineType { get; set; } = null!;
    }
}
