using FoodDeliveryApp.Models.Restaurant;

namespace FoodDeliveryApp.Services.Restaurants
{
    public interface IRestaurantService
    {
        RestaurantQueryServiceModel All(string cuisineType,
            string searchTerm,
            RestaurantSorting sorting,
            int currentPage,
            int restaurantsPerPage);

        IEnumerable<string> AllCuisineTypes();
    }
}
