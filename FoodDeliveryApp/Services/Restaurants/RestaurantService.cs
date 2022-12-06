using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodDeliveryApp.Data;
using FoodDeliveryApp.Models.Restaurant;
using FoodDeliveryApp.Services.Restaurants.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly FoodDeliveryAppDbContext data;
        private readonly IMapper mapper;

        public RestaurantService(FoodDeliveryAppDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public RestaurantQueryServiceModel All(
                                    string cuisineType,
                                    string searchTerm,
                                    RestaurantSorting sorting,
                                    int currentPage,
                                    int restaurantsPerPage)
        {
            var restaurantsQuery = this.data.Restaurants.AsQueryable().Where(r => r.IsActive);
            if (!string.IsNullOrWhiteSpace(cuisineType))
            {
                restaurantsQuery = restaurantsQuery.Where(r => r.CuisineType.Name == cuisineType);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                //TODO this sorting does not work. Check why!!

                //restaurantsQuery = restaurantsQuery.Where(r =>
                //    r.Name.ToLower().Contains(searchTerm) ||
                //    r.CuisineType.Name.ToLower().Contains(searchTerm));

                //TODO when performing search "a" and hit next-page-btn "a" becomes "%a%" check why!!!
                restaurantsQuery = restaurantsQuery
                   .Where(r => EF.Functions.Like(r.Name.ToLower(), searchTerm) ||
                   EF.Functions.Like(r.CuisineType.Name.ToLower(), searchTerm));
            };


            //TODO CHECK WHY ORDER BY RATING DOES NOT WORK!
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
                    CuisineType = r.CuisineType.Name,
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

        public IEnumerable<RestaurantCuisineTypeModel> GetAllCuisineTypes()
        {
            return this.data
                   .CuisineTypes
                   .Select(r => new RestaurantCuisineTypeModel()
                   {
                       Id = r.Id,
                       Name = r.Name
                   })
                   .ToList();
        }
        public int GetCuisineTypeId(int restaurantId)
        {
            return this.data.Restaurants.Where(r => r.Id == restaurantId).Select(r => r.CuisineTypeId).FirstOrDefault();
        }
        public RestaurantDetailsModel Details(int id)
        {
            return this.data
                .Restaurants
                .Where(r=>r.IsActive)
                .Where(r => r.Id == id)
                .ProjectTo<RestaurantDetailsModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public void Edit(int restaurantId, RestaurantFormModel restaurant)
        {
            var restaurantData = this.data.Restaurants.Find(restaurantId);

            restaurantData.Name = restaurant.Name;
            restaurantData.RestaurantImage = restaurant.RestaurantImage;
            restaurantData.Description = restaurant.Description;
            restaurantData.Rating = restaurant.Rating;
            restaurantData.WorkingHours = restaurant.WorkingHours;
            restaurantData.DeliveryCost = restaurant.DeliveryCost;
            restaurantData.MinOrderAmount = restaurant.MinOrderAmount;
            restaurantData.DeliveryTime = restaurant.DeliveryTime;
            restaurantData.CuisineTypeId = restaurant.CuisineTypeId;

            this.data.SaveChanges();
        }

        public bool RestaurantExist(int restaurantId)
        {
            return this.data.Restaurants.Any(r => r.Id == restaurantId && r.IsActive);
        }

        public bool CuisineTypeExist(int cuisineTypeId)
        {
            return this.data.CuisineTypes.Any(c => c.Id == cuisineTypeId);
        }

        public void Delete(int restaurantId)
        {
            var restaurant = this.data.Restaurants.Find(restaurantId);
            restaurant.IsActive = false;

            this.data.SaveChanges();
        }
    }
}
