using System.Security.Claims;

namespace FoodDeliveryApp.Infrastructures
{
    public static class ClaimsPrincipalExtentions
    {
        public static string GetId( this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
