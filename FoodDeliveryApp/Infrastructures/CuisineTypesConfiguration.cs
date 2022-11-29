using FoodDeliveryApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructures
{
    public class CuisineTypesConfiguration : IEntityTypeConfiguration<CuisineType>
    {
        public void Configure(EntityTypeBuilder<CuisineType> builder)
        {
            builder.HasData(CreateCuiseneTypes());
        }

    
        private List<CuisineType> CreateCuiseneTypes()
        {
            var types = new List<CuisineType>()
            {
                new CuisineType{Id =1, Name= "Indian"},
                new CuisineType{Id =2,Name= "Burgers"},
                new CuisineType{Id =3,Name= "Sishi"},
                new CuisineType{Id =4,Name= "Italian"},
                new CuisineType{Id =5,Name= "Asian"},
                new CuisineType{Id =6,Name= "Bulgarian"},
                new CuisineType{Id =7,Name= "Arab"},
                new CuisineType{Id =8,Name= "Pizza"},
                new CuisineType{Id =9,Name= "Vegetarian"},
                new CuisineType{Id =10,Name= "Europian"},
                new CuisineType{Id =11,Name= "Mexican"},
                new CuisineType{Id =12,Name= "Fine dine"}
            };
            return types;
        }
    }
}
