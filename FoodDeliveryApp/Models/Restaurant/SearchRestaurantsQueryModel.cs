using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models.Restaurant
{
    public class SearchRestaurantsQueryModel
    {
        public const int RestaurantsPerPage = 3;

        public string CuisineType { get; set; } = null!;


        [Display(Name = "Search")]
        public string SearchTerm { get; set; } = null!;
        public RestaurantSorting Sorting { get; set; }
        public int CurrentPage { get; set; } = 1;

        public int TotalRestairants { get; set; }
        public List<string> CuisineTypes { get; set; } = null!;
        public IEnumerable<RestaurantListingViewModel> Restaurants { get; set; }
    }
}
