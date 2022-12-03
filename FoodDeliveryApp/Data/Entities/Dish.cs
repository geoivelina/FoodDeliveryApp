using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Dish;
namespace FoodDeliveryApp.Data.Entities
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        //TODO CHANGE THIS ONE TO FILE UPLOAD
        public string DishImage { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Descriprion { get; set; } = null!;

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
