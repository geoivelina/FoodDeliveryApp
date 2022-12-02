using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Data.DataConstants.User;

namespace FoodDeliveryApp.Data.Entities
{
    public class User: IdentityUser
    {
        [StringLength(FullNameMaxLength)]
        public string FullName { get; set; }
    
    }
}
