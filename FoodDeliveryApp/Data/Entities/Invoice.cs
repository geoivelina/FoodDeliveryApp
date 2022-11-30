using FoodDeliveryApp.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Data.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}
