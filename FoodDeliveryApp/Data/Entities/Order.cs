using FoodDeliveryApp.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;

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
        
        [Precision(18,2)]
        public decimal TotalAmount { get; set; }

    }
}
