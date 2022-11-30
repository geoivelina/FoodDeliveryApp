using FoodDeliveryApp.Data;
using FoodDeliveryApp.Models;
using FoodDeliveryApp.Models.Home;
using FoodDeliveryApp.Services.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodDeliveryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FoodDeliveryAppDbContext data;
        private readonly IStatisticsService statistics;
        public HomeController(
          IStatisticsService statistics,
            FoodDeliveryAppDbContext data)
        {
            this.data = data;
            this.statistics = statistics;
        }


        public IActionResult Index()
        {

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

            var statistics = this.statistics.GetStatistics();


            return View(new IndexViewModel
            {
                TotalRestaurants = statistics.TotalRestaurants,
                Restaurants = restaurants,
                TotalUsers = statistics.TotalUsers,
                TotalOrders = statistics.TotalOrders,
            });
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}