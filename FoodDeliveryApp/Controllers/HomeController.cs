using FoodDeliveryApp.Data;
using FoodDeliveryApp.Models;
using FoodDeliveryApp.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodDeliveryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FoodDeliveryAppDbContext data;

        public HomeController(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }


        public IActionResult Index()
        {
            var totalRestaurants = this.data.Restaurants.Count();
            var restaurants = this.data
                .Restaurants
                .OrderByDescending(r => r.Id)
                .Select(r => new RestaurantIndexModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    RestaurantImage = r.RestaurantImage
                })
                .Take(5)
                .ToList();



            return View(new IndexViewModel
            {
                TotalRestaurants = totalRestaurants,
                Restaurants = restaurants
            });
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}