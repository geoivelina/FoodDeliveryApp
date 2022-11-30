using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.City;
namespace FoodDeliveryApp.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }
        public IEnumerable<Address> Addresses { get; set; } = new List<Address>();
    }
}
