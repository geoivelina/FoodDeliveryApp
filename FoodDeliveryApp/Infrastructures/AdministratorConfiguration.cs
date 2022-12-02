using FoodDeliveryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructures
{
    public class AdministratorConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateCuiseneTypes());
        }


        private List<User> CreateCuiseneTypes()
        {
            var users = new List<User>()
            {
                
            };
            return users;
        }
    }
  
}
