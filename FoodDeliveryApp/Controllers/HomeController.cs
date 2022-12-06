using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;
        public HomeController(
          IStatisticsService statistics,
            FoodDeliveryAppDbContext data,
            IMapper mapper)
        {
            this.data = data;
            this.statistics = statistics;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {

            var restaurants = this.data
                .Restaurants
                .Where(r => r.IsActive)
                .OrderByDescending(r => r.Id)
                .ProjectTo<RestaurantIndexModel>(this.mapper.ConfigurationProvider)
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