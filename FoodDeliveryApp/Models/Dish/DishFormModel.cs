using FoodDeliveryApp.Services.Dishes;
using FoodDeliveryApp.Services.Restaurants.Models;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Dish;

namespace FoodDeliveryApp.Models.Dish
{
    public class DishFormModel
    {

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        //TODO CHANGE THIS ONE TO FILE UPLOAD
        public string DishImage { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Descriprion { get; set; } = null!;

        [Required]
        [Display(Name = "Choose a menu")]
        public int MenuId { get; set; }
        public IEnumerable<DishMenusServiceModels> Menus { get; set; } = new List<DishMenusServiceModels>();

        [Required]
        [Display(Name = "Choose a restaurant")]
        public int RestaurantId { get; set; }
        public IEnumerable<DishRestaurantServiceModel> Restaurants { get; set; } = new List<DishRestaurantServiceModel>();
    }
}
