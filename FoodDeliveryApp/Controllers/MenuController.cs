using FoodDeliveryApp.Models.Menu;
using FoodDeliveryApp.Data.Entities;
using FoodDeliveryApp.Services.Menus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMenuService menus;

        public MenuController(IMenuService menus)
        {
            this.menus = menus;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new MenuFormModel
            {
                Restaurants = this.menus.GetAllRestaurants()
            });
        }

        [HttpPost]
        public IActionResult Add(MenuFormModel menu)
        {
            if (this.menus.RestaurantExist(menu.RestaurantId))
            {
                this.ModelState.AddModelError(nameof(menu.RestaurantId), "Restaurant does not exist");
            }

            if (!ModelState.IsValid)
            {
                menu.Restaurants = this.menus.GetAllRestaurants();
                return View(menu);
            }


            var menuData = new Menu
            {
                Name = menu.Name,
                RestaurantId = menu.RestaurantId
            };

            this.menus.Create(menu.Name, menu.RestaurantId);
            return RedirectToAction("Index", "Home");
        }
    }
}
