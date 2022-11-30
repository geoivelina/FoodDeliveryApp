using FoodDeliveryApp.Data;
using FoodDeliveryApp.Services.Models;

namespace FoodDeliveryApp.Services.Statistics
{
    public class StatisticService : IStatisticsService
    {
        private readonly FoodDeliveryAppDbContext data;

        public StatisticService(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }

        public StatisticsServiceModel GetStatistics()
        {

            var totalRestaurants = data.Restaurants.Count();
            var toralUsers = data.Users.Count();
            return new StatisticsServiceModel
            {
                TotalOrders = 0,
                TotalRestaurants = data.Restaurants.Count(),
                TotalUsers = 0
            };
        }
    }
}
