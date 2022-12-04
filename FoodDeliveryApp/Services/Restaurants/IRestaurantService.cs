using FoodDeliveryApp.Services.Restaurants.Models;

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
