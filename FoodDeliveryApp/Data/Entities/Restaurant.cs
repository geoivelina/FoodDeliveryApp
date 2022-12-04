using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.Restaurant;

namespace FoodDeliveryApp.Data.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        //TODO CHANGE THIS ONE TO FILE UPLOAD
        public string RestaurantImage { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(WorkingHoursMaxLength)]
        public string WorkingHours { get; set; } = null!;

        [Required]
        [StringLength(DeliveryCostMaxLength)]
        public string DeliveryCost { get; set; } = null!;

        [Required]
        [StringLength(DeliveryTimeMaxLength)]
        public string DeliveryTime { get; set; } = null!;

        [Required]
        [StringLength(MinOrderAmountMaxLength)]
        public string MinOrderAmount { get; set; } = null!;

        [Required]
        [Range(0.00, 10.00)]
        [Precision(4,2)]
        public decimal Rating { get; set; }

        public int CuisineTypeId { get; set; }
        public CuisineType CuisineType { get; set; } = null!;
        public IEnumerable<Menu> Menus { get; set; } = new List<Menu>();
        public IEnumerable<Dish> Dishes { get; set; } = new List<Dish>();

    }
}
