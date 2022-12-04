using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Menu;

namespace FoodDeliveryApp.Data.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public IEnumerable<Dish> Dishes { get; set; } = new List<Dish>();

    }
}
