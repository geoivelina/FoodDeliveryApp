namespace FoodDeliveryApp.Services.CuisineTypes
{
    public interface ICuisineTypeService
    {
        int Create(int id, string Name);
        bool CuisineTypeExist(string cuisineTypeName);
    }
}
