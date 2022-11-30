using FoodDeliveryApp.Data;
using FoodDeliveryApp.Models.Restaurant;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Services.Restaurant
{
    public class RestaurantService : IRestaurantService
    {
        private readonly FoodDeliveryAppDbContext data;

        public RestaurantService(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }
        public RestaurantQueryServiceModel All(
                                    string cuisineType,
                                    string searchTerm,
                                    RestaurantSorting sorting,
                                    int currentPage,
                                    int restaurantsPerPage)
        {
            var restaurantsQuery = this.data.Restaurants.AsQueryable();
            if (!string.IsNullOrWhiteSpace(cuisineType))
            {
                restaurantsQuery = restaurantsQuery.Where(r => r.CuisineType.Name == cuisineType);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                // this sorting does not work. Check why
                //restaurantsQuery = restaurantsQuery.Where(r =>
                //    r.Name.ToLower().Contains(searchTerm) ||
                //    r.CuisineType.Name.ToLower().Contains(searchTerm));

                //when performing search "a" and hit next page btn "a"becomes "%a%" check why
                restaurantsQuery = restaurantsQuery
                   .Where(r => EF.Functions.Like(r.Name.ToLower(), searchTerm) ||
                   EF.Functions.Like(r.CuisineType.Name.ToLower(), searchTerm));
            };


            //TODO CHECK WHY ORDER BY RATINGG DOES NOT WORK!
            restaurantsQuery = sorting switch
            {
                RestaurantSorting.LastAdded => restaurantsQuery.OrderByDescending(r => r.Id),
                RestaurantSorting.BestMatch => restaurantsQuery.OrderByDescending(r => r.Name),
                RestaurantSorting.Rating => restaurantsQuery.OrderByDescending(r => r.Rating).ThenBy(r => r.Name),
                _ => restaurantsQuery.OrderByDescending(r => r.Id)
            };

            var totalRestaurants = restaurantsQuery.Count();

            var restaurants = restaurantsQuery
                .Skip((currentPage - 1) * restaurantsPerPage)
                .Take(restaurantsPerPage)
                .OrderByDescending(r => r.Id)
                .Select(r => new RestaurantServiceModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    RestaurantImage = r.RestaurantImage,
                    Category = r.CuisineType.Name,
                    DeliveryCost = r.DeliveryCost,
                    DeliveryTime = r.DeliveryTime,
                    MinOrderAmount = r.MinOrderAmount,
                    Rating = r.Rating,
                    WorkingHours = r.WorkingHours
                })
                .ToList();

            return new RestaurantQueryServiceModel
            {
                TotalRestaurants = totalRestaurants,
                CurrentPage = currentPage,
                RestaurantsPerPage = restaurantsPerPage,
                Restaurants = restaurants

            };
        }

        public IEnumerable<string> AllCuisineTypes()
        {
            return this.data
                   .Restaurants
                   .Select(r => r.CuisineType.Name)
                   .OrderBy(r => r)
                   .Distinct()
                   .OrderBy(ct => ct)
                   .ToList();
        }

    }
}
