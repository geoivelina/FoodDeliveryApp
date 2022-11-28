using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Data.Migrations
{
    public partial class RestaurantAndCuisineTypeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuisineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WorkingHours = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DeliveryCost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MinOrderAmount = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Rading = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CuisineTipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_CuisineTypes_CuisineTipeId",
                        column: x => x.CuisineTipeId,
                        principalTable: "CuisineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CuisineTipeId",
                table: "Restaurants",
                column: "CuisineTipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "CuisineTypes");
        }
    }
}
