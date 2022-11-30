using FoodDeliveryApp.Data.Entities.Enums;

namespace FoodDeliveryApp.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
