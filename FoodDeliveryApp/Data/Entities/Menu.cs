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

    }
}
