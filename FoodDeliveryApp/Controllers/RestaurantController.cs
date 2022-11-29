using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Models.Restaurant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly FoodDeliveryAppDbContext data;

        public RestaurantController(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddRestaurantFormModel
            {
                CuisineTypes = this.GetRestaurantCuisineTypeModels()
            });
        }

        [HttpPost]
        public IActionResult Add(AddRestaurantFormModel restaurant)
        {
            if (!this.data.CuisineTypes.Any(c => c.Id == restaurant.CuisineTypeId))
            {
                this.ModelState.AddModelError(nameof(restaurant.CuisineTypeId), "Cuisine type is not valid");
            }

            if (!ModelState.IsValid)
            {
                restaurant.CuisineTypes = this.GetRestaurantCuisineTypeModels();
                return View(restaurant);
            }
            var restaurantData = new Restaurant
            {
                Name = restaurant.Name,
                Description = restaurant.Description,
                CuisineTypeId = restaurant.CuisineTypeId,
                DeliveryCost = restaurant.DeliveryCost,
                DeliveryTime = restaurant.DeliveryTime,
                MinOrderAmount = restaurant.MinOrderAmount,
                RestaurantImage = restaurant.RestaurantImage,
                WorkingHours = restaurant.WorkingHours,
                Rating = restaurant.Rating,


            };

            this.data.Restaurants.Add(restaurantData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        public IActionResult All([FromQuery] SearchRestaurantsQueryModel query
            )
        {
            var restaurantsQuery = this.data.Restaurants.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CuisineType))
            {
                restaurantsQuery = restaurantsQuery.Where(r => r.CuisineType.Name == query.CuisineType);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                query.SearchTerm = $"%{query.SearchTerm.ToLower()}%";
                // this sorting does not work. Check why
                //restaurantsQuery = restaurantsQuery.Where(r =>
                //    r.Name.ToLower().Contains(searchTerm) ||
                //    r.CuisineType.Name.ToLower().Contains(searchTerm));

                //when performing search "a" and hit next page btn "a"becomes "%a%" check why
                restaurantsQuery = restaurantsQuery
                   .Where(r => EF.Functions.Like(r.Name.ToLower(), query.SearchTerm) ||
                   EF.Functions.Like(r.CuisineType.Name.ToLower(), query.SearchTerm));
            };


            //TODO CHECK WHY ORDER BY RATINGG DOES NOT WORK!
            restaurantsQuery = query.Sorting switch
            {
                RestaurantSorting.LastAdded => restaurantsQuery.OrderByDescending(r => r.Id),
                RestaurantSorting.BestMatch => restaurantsQuery.OrderByDescending(r => r.Name),
                RestaurantSorting.Rating => restaurantsQuery.OrderByDescending(r => r.Rating).ThenBy(r => r.Name),
                _ => restaurantsQuery.OrderByDescending(r => r.Id)
            };

            var totalRestaurants = restaurantsQuery.Count();

            var restaurants = restaurantsQuery
                .Skip((query.CurrentPage - 1) * SearchRestaurantsQueryModel.RestaurantsPerPage)
                .Take(SearchRestaurantsQueryModel.RestaurantsPerPage)
                .OrderByDescending(r => r.Id)
                .Select(r => new RestaurantListingViewModel
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

            var cuisineTypes = this.data
                .Restaurants
                .Select(r => r.CuisineType.Name)
                .OrderBy(r => r)
                .Distinct()
                .OrderBy(ct => ct)
                .ToList();


            query.CuisineTypes = cuisineTypes;
            query.Restaurants = restaurants;
            query.TotalRestairants = totalRestaurants;
            return View(query);
        }

        private IEnumerable<RestaurantCuisineTypeModel> GetRestaurantCuisineTypeModels()
        {
            return this.data
                    .CuisineTypes
                    .Select(c => new RestaurantCuisineTypeModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToList();
        }
    }
}
