using AutoMapper;
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
        private readonly IMapper mapper;

        public RestaurantController(
            IRestaurantService restaurants,
            FoodDeliveryAppDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.restaurants = restaurants;
            this.mapper = mapper;
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

            var cuisineTypes = this.restaurants.GetAllCuisineTypes();

            query.TotalRestairants = queryResult.TotalRestaurants;
            query.CuisineTypes = cuisineTypes;
            query.Restaurants = queryResult.Restaurants;

            return View(query);
        }

        public IActionResult Details(int id)
        {
            if (!this.restaurants.RestaurantExist(id))
            {
                return BadRequest();
            }

            var restaurantMOdel = this.restaurants.Details(id);

            return View(restaurantMOdel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            //TODO CHECK IF USER IS ADMIN

            if (restaurants.RestaurantExist(id) == false)
            {
                return BadRequest();
            }

            var restaurantData = this.restaurants.Details(id);

           
            var restaurant = this.mapper.Map<RestaurantFormModel>(restaurantData);
         

            restaurant.CuisineTypes = this.restaurants.GetAllCuisineTypes();

            return View(restaurant);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(RestaurantFormModel restaurant)
        {
            //TODO CHECK IF USER IS ADMIN
            if (!this.restaurants.RestaurantExist(restaurant.Id))
            {
                return this.View();
            }

            if (!this.restaurants.CuisineTypeExist(restaurant.CuisineTypeId))
            {
                this.ModelState.AddModelError(nameof(restaurant.CuisineTypeId), "Cuisine Type does not exist");
            }

            if (!ModelState.IsValid)
            {
                restaurant.CuisineTypes = this.restaurants.GetAllCuisineTypes();
                return View(restaurant);
            }

           this.restaurants.Edit(restaurant.Id, restaurant) ;


            return RedirectToAction(nameof(All));
        }


        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //TODO CHECK IF THE USER IS ADMIN
            if (restaurants.RestaurantExist(id) == false)
            {
                return BadRequest();
            }

            var restaurantData = this.restaurants.Details(id);

            var restaurant = this.mapper.Map<RestaurantDeleteViewMOdel>(restaurantData);

            return View(restaurant);

        }


        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id, RestaurantDeleteViewMOdel restaurant)
        {
            //TODO CHECK IF THE USER IS ADMIN
            if (restaurants.RestaurantExist(id) == false)
            {
                return BadRequest();
            }

            restaurants.Delete(id);

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
