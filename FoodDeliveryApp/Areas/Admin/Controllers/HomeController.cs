using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
