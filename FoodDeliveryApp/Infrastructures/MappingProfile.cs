using AutoMapper;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Models.Home;
using FoodDeliveryApp.Models.Restaurant;
using FoodDeliveryApp.Services.Dishes;
using FoodDeliveryApp.Services.Restaurants.Models;

namespace FoodDeliveryApp.Infrastructures
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            this.CreateMap<RestaurantDetailsModel, RestaurantFormModel>();
            this.CreateMap<Restaurant, RestaurantDetailsModel>();
            this.CreateMap<Restaurant, RestaurantIndexModel>();
            this.CreateMap<RestaurantDetailsModel, RestaurantDeleteViewMOdel>();
            this.CreateMap<Menu, RestaurantMenuModel>();
            this.CreateMap<Dish, DishesServiceModel>();
        }
    }
}
