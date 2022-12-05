using FoodDeliveryApp.Services.Menus;
using FoodDeliveryApp.Services.Restaurants.Models;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Menu;

namespace FoodDeliveryApp.Models.Menu
{
    public class MenuFormModel
    {

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Display(Name ="Restaurant Name")]
        public int RestaurantId { get; set; }
        public IEnumerable<MenuRestaurantServiceModel> Restaurants { get; set; } = new List<MenuRestaurantServiceModel>();
    }
}
