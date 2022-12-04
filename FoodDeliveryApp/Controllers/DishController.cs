using FoodDeliveryApp.Models.Dish;
using FoodDeliveryApp.Services.Dishes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{

    [Authorize]
    public class DishController : Controller
    {
        private readonly IDishService dishes;

        public DishController(IDishService dishes)
        {
            this.dishes = dishes;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new DishFormModel()
            {
                //Menus = this.dishes.,
                Restaurants = this.dishes.GetAllRestaurants()
                
            });
        }


        [HttpPost]
        public IActionResult Add(DishFormModel dish)
        {
            if (!this.dishes.MenuExist(dish.MenuId))
            {
                this.ModelState.AddModelError(nameof(dish.MenuId), "Menu does not exist");
            }
            if (!this.dishes.RestaurantExist(dish.RestaurantId))
            {
                this.ModelState.AddModelError(nameof(dish.RestaurantId), "Restaurant does not exist");
            }

            if (!ModelState.IsValid)
            {
               // dish.Menus = this.dishes.GetAllMenues();
                dish.Restaurants = this.dishes.GetAllRestaurants();
                return View(dish);
            }

            this.dishes.Create(dish.Name, dish.Descriprion, dish.DishImage, dish.Price, dish.MenuId, dish.RestaurantId);
          
            return RedirectToAction("Index", "Home");

        }

     
    }
}
