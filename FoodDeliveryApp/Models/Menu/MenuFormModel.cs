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
        public int RestaurantId { get; set; }
        public IEnumerable<RestaurantServiceModel> Restaurants { get; set; } = new List<RestaurantServiceModel>();
    }
}
