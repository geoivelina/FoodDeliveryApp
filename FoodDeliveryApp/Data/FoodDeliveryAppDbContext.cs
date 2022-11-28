using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp.Data
{
    public class FoodDeliveryAppDbContext : IdentityDbContext
    {
        public FoodDeliveryAppDbContext(DbContextOptions<FoodDeliveryAppDbContext> options)
            : base(options)
        {
        }
    }
}