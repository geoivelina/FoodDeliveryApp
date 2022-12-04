namespace FoodDeliveryApp.Services.Dishes
{
    public class DishesServiceModel
    {
        public string Name { get; set; } = null!;

       
        public string DishImage { get; set; } = null!;

        public decimal Price { get; set; }

        public string Descriprion { get; set; } = null!;
    }
}
