using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;

namespace FoodDeliveryApp.Services.CuisineTypes
{
    public class CuisineTypeService : ICuisineTypeService
    {
        private readonly FoodDeliveryAppDbContext data;

        public CuisineTypeService(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }

        public int Create(int id, string Name)
        {
            var cuisineType = new CuisineType
            {
                Id = id,
                Name = Name
            };

            this.data.CuisineTypes.Add(cuisineType);
            this.data.SaveChanges();

            return cuisineType.Id;
        }

        public bool CuisineTypeExist(int cuisineTypeId)
        {
            return this.data.CuisineTypes.Any(ct=> ct.Id == cuisineTypeId);
        }
    }
}
