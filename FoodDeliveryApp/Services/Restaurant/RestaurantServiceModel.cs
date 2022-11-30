namespace FoodDeliveryApp.Services.Restaurant
{
    public class RestaurantServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string RestaurantImage { get; set; } = null!;

        public decimal Rating { get; set; }

        public string WorkingHours { get; set; } = null!;

        public string DeliveryCost { get; set; } = null!;

        public string MinOrderAmount { get; set; } = null!;

        public string DeliveryTime { get; set; } = null!;
        public string Category { get; set; }

    }
}
