using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Data.Migrations
{
    public partial class FixingTypos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTipeId",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Restaurants",
                newName: "RestaurantImage");

            migrationBuilder.RenameColumn(
                name: "CuisineTipeId",
                table: "Restaurants",
                newName: "CuisineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CuisineTipeId",
                table: "Restaurants",
                newName: "IX_Restaurants_CuisineTypeId");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTime",
                table: "Restaurants",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTypeId",
                table: "Restaurants",
                column: "CuisineTypeId",
                principalTable: "CuisineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTypeId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "RestaurantImage",
                table: "Restaurants",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "CuisineTypeId",
                table: "Restaurants",
                newName: "CuisineTipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurants_CuisineTypeId",
                table: "Restaurants",
                newName: "IX_Restaurants_CuisineTipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_CuisineTypes_CuisineTipeId",
                table: "Restaurants",
                column: "CuisineTipeId",
                principalTable: "CuisineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
