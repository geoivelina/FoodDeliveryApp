using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodDeliveryApp.Areas.Admin.AdminConstants;

namespace FoodDeliveryApp.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles =AdminRoleName)]
    public class AdminController : Controller
    {
    }
}
