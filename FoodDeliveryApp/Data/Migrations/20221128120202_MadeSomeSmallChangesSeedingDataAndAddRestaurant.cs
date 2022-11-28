using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Data.Migrations
{
    public partial class MadeSomeSmallChangesSeedingDataAndAddRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CuisineTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Indian" },
                    { 2, "Burgers" },
                    { 3, "Sishi" },
                    { 4, "Italian" },
                    { 5, "Asian" },
                    { 6, "Bulgarian" },
                    { 7, "Arab" },
                    { 8, "Pizza" },
                    { 9, "Vegetarian" },
                    { 10, "Europian" },
                    { 11, "Mexican" },
                    { 12, "Fine dine" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "CuisineTypeId", "DeliveryCost", "DeliveryTime", "Description", "MinOrderAmount", "Name", "Rading", "RestaurantImage", "WorkingHours" },
                values: new object[,]
                {
                    { 1, 8, "Free", "20 - 50 min.", "Authentic Italian pizza", "Min. 10.00 lv.", "Genaro`s pizza", 0m, "https://tse1.mm.bing.net/th?id=OIP.VIHoNlxPTkXfW2i6DgfIbwHaF7&pid=Api", "12:00 - 22:00" },
                    { 2, 1, "Free from 30.00 lv.", "30 - 50 min.", "Authentic Indian pizza", "Min. 20.00 lv.", "Taj Mahal", 0m, "https://tse2.mm.bing.net/th?id=OIP.8gNduGMsG-TnwPqLDlRQVQHaE8&pid=Api", "11:00 - 23:00" },
                    { 3, 2, "Free from 20.00 lv.", "20 - 50 min.", "Best American style burgers", "Min. 20.00 lv.", "Burgers & Fries", 0m, "https://tse1.mm.bing.net/th?id=OIP.W0r1nOj-EPrXoziOqjjFPAHaE8&pid=Api", "11:00 - 23:00" },
                    { 4, 11, "2.99 lv.", "20 - 50 min.", "Cosy Mexican restaurant in the heart of the big city", "Min. 20.00 lv.", "El Gatto", 0m, "https://tse4.mm.bing.net/th?id=OIP.Q74hg6Rl1KPSs-0sUXcXugHaE8&pid=Api", "11:00 - 22:00" },
                    { 5, 3, "2.99 lv.", "30 - 60 min.", "Authentic sushi prepared from our sushi master", "Min. 20.00 lv.", "Kioto sushi", 0m, "https://tse3.mm.bing.net/th?id=OIP.2oT2R6wz3DbEm0NIePcJzwHaE_&pid=Api", "11:00 - 24:00" },
                    { 6, 5, "5.99 lv.", "30 - 60 min.", "Authentic Chinese dishes", "Min. 10.00 lv.", "Golden dragon", 0m, "https://tse2.mm.bing.net/th?id=OIP.GvVXxZP0xh8i9a_1XFmTyAHaE8&pid=Api", "12:00 - 22:00" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CuisineTypes",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
