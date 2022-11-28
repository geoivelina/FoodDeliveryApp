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

        public IActionResult All(string searchTerm)
        {
            var restaurantsQuery = this.data.Restaurants.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = $"%{searchTerm.ToLower()}%";
                //restaurantsQuery = restaurantsQuery.Where(r =>
                //    r.Name.ToLower().Contains(searchTerm) ||
                //    r.CuisineType.Name.ToLower().Contains(searchTerm));
                restaurantsQuery = restaurantsQuery
                   .Where(r => EF.Functions.Like(r.Name.ToLower(), searchTerm) ||
                   EF.Functions.Like(r.CuisineType.Name.ToLower(), searchTerm));
            };

            var restaurants = restaurantsQuery
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

            return View(new SearchRestaurantsQueryModel
            {
                Restaurants = restaurants
            });
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
