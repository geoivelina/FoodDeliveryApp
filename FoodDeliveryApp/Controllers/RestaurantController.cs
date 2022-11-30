using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Models.Restaurant;
using FoodDeliveryApp.Services.Restaurant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurants;
        private readonly FoodDeliveryAppDbContext data;

        public RestaurantController(
            IRestaurantService restaurants,
            FoodDeliveryAppDbContext data)
        {
            this.data = data;
            this.restaurants = restaurants;
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

        [HttpGet]
        public IActionResult All([FromQuery] SearchRestaurantsQueryModel query)
        {
            var queryResult = this.restaurants.All(
                query.CuisineType,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                SearchRestaurantsQueryModel.RestaurantsPerPage);

            var cuisineTypes = this.restaurants.AllCuisineTypes();

            query.TotalRestairants = queryResult.TotalRestaurants;
            query.CuisineTypes = cuisineTypes;
            query.Restaurants = queryResult.Restaurants;

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
