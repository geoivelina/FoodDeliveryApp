using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Customer;

namespace FoodDeliveryApp.Data.Entities
{
    public class Customer 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
     
    }
}
