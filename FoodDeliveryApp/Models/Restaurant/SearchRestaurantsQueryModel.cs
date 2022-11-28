using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models.Restaurant
{
    public class SearchRestaurantsQueryModel
    {
        public IEnumerable<string> CuisineTypes { get; set; } = null!;
        [Display(Name = "Search")]
        public string SearchTerm { get; set; } = null!;
        public RestaurantSorting Sorting { get; set; } 
        public IEnumerable<RestaurantListingViewModel> Restaurants { get; set; }
    }
}
