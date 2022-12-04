using FoodDeliveryApp.Data;
using FoodDeliveryApp.Data.Entities;


namespace FoodDeliveryApp.Services.Menus
{
    public class MenuService : IMenuService
    {
        private readonly FoodDeliveryAppDbContext data;

        public MenuService(FoodDeliveryAppDbContext data)
        {
            this.data = data;
        }

 

        public int Create(string name)
        {
            var menuModel = new Menu
            {
                Name = name
            };

            this.data.Menus.Add(menuModel);
            this.data.SaveChanges();

            return menuModel.Id;
        }

       
    }
}
