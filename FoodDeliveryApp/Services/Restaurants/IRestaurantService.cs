using FoodDeliveryApp.Models.Restaurant;
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

        IEnumerable<RestaurantCuisineTypeModel> GetAllCuisineTypes();

        int GetCuisineTypeId(int restaurantId);
        bool RestaurantExist(int restaurantId);
        bool CuisineTypeExist( int cuisineTypeId);

        RestaurantDetailsModel Details(int id);
        void Edit(int restaurantId, RestaurantFormModel restaurant);
        void Delete(int restaurantId);
    }
}
