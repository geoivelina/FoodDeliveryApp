using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Models.Restaurant;
using FoodDeliveryApp.Services.Restaurants;
using FoodDeliveryApp.Services.Restaurants.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Controllers
{
    [Authorize]
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


        [HttpGet]

        public IActionResult Add()
        {
            return View(new RestaurantFormModel
            {
             CuisineTypes = this.GetRestaurantCuisineTypeModels()
            });
        }

        [HttpPost]
        public IActionResult Add(RestaurantFormModel restaurant)
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
        public IActionResult Details( int id)
        {
            return View(new RestaurantDetailsModel());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(new RestaurantFormModel());
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, RestaurantDetailsModel restaurant)
        {
            return RedirectToAction(nameof(All));
        }


        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new RestaurantDetailsModel());
        }


        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id, RestaurantDetailsModel restaurant)
        {
            return RedirectToAction(nameof(All));
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
