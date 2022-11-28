namespace FoodDeliveryApp.Data
{
    public class DataConstants
    {
        public class Restaurant
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 200;

            public const int WorkingHoursMinLength = 9;
            public const int WorkingHoursMaxLength = 13;

            public const int DeliveryCostMinLength = 4;
            public const int DeliveryCostMaxLength = 50;

            public const int MinOrderAmountMaxLength = 15;

            public const int DeliveryTimeMaxLength = 15;

        }

        public class CuisineType
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 15;
        }
        public class User
        {
            public const int FullNameMinLength = 6;
            public const int FullNameMaxLength = 15;


            public const int AddressMinLength = 4;
            public const int AddressMaxLength = 70;

        }

        public class Dish
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 15;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 200;
        }
    }
}
