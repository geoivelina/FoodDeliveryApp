using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.CuisineType;

namespace FoodDeliveryApp.Data.Entities
{
    public class CuisineType
    {
        public int Id { get; set; }

        [Required]

        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public IEnumerable<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
