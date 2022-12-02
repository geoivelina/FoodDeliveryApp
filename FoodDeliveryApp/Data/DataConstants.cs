namespace FoodDeliveryApp.Data
{
    public class DataConstants
    {
        public class Address
        {
            public const int NeighbourhoodMinLenght = 4;
            public const int NeighbourhoodMaxLenght = 50;

            public const int StreetNameMinLength = 4;
            public const int StreetNameMaxLength = 50;

            public const int StreetNumberMinLength = 1;
            public const int StreetNumberMaxLength = 5;


            public const int AppartmentNumberMinLength = 1;
            public const int AppartmentNumberMaxLength = 5;

            public const int PostCodeMaxLength = 4;
        }

        public class City
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 20;
        }
        public class CuisineType
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 15;
        }
        public class Customer
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 30;

            public const int PhoneNumberMaxLength = 15;
        }

        public class Dish
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 15;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 200;
        }

        
        public class Menu
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
        }
        public class Order
        {

        }

       
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

        public class User
        {
            public const int FullNameMinLength = 6;
            public const int FullNameMaxLength = 30;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }

      
            
    }
}
