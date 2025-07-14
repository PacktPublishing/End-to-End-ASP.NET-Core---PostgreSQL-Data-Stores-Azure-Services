using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Neon.CRM.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedingVacationPackages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VacationPackages",
                columns: new[] { "Id", "Description", "DurationInDays", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Experience the beauty of tropical beaches and lush landscapes.", 7, 1999.99m, "Tropical Paradise" },
                    { 2, "Experience the thrill of hiking, camping, and breathtaking mountain views for 7 days.", 7, 1299.50m, "Mountain Adventure" },
                    { 3, "Visit historic cities across Europe on a 10-day guided luxury tour.", 10, 2499.00m, "European Explorer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VacationPackages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VacationPackages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VacationPackages",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
