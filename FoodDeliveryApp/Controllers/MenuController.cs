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
            return View();
        }

        [HttpPost]
        public IActionResult Add(MenuFormModel menu)
        {
            if (!ModelState.IsValid)
            {
                return View(menu);
            }


            var menuData = new Menu
            {
                Name = menu.Name,
                RestaurantId = menu.RestaurantId
            };

            this.menus.Create(menu.Name);
            return RedirectToAction("Index", "Home");
        }
    }
}
