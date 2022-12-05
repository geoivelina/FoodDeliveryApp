using FoodDeliveryApp.Models.CuisineType;
using FoodDeliveryApp.Services.CuisineTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    [Authorize]
    public class CuisineTypeController : Controller
    {
        private readonly ICuisineTypeService cuisineTypes;

        public CuisineTypeController(ICuisineTypeService cuisineTypes)
        {
            this.cuisineTypes = cuisineTypes;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CuisineTypeFormModel cuisine)
        {
            if (this.cuisineTypes.CuisineTypeExist(cuisine.Name)== true)
            {
                this.ModelState.AddModelError(nameof(cuisine.Name), "This cuisine type already exist");
            }

            if (!ModelState.IsValid)
            {
                return View(cuisine);
            }

            this.cuisineTypes.Create(cuisine.Id, cuisine.Name);

            return RedirectToAction("Index", "Home");
        }
    }
}
