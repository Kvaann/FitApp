using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitApp.Api.Migrations
{
    public partial class initialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "MealFoodItems",
                newName: "MealFoodItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MealFoodItemId",
                table: "MealFoodItems",
                newName: "MyProperty");
        }
    }
}
