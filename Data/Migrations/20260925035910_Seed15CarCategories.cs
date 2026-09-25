using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed15CarCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Affordable compact cars for city driving");

            migrationBuilder.UpdateData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Premium vehicles with high comfort");

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "CategoryId", "BaseDailyRate", "CategoryName", "Description", "IsActive" },
                values: new object[,]
                {
                    { 4, 22m, "Compact", "Small cars ideal for parking and short trips", true },
                    { 5, 35m, "Sedan", "Comfortable mid-size sedans", true },
                    { 6, 28m, "Hatchback", "Practical hatchbacks for daily use", true },
                    { 7, 95m, "Convertible", "Open-top cars for leisure driving", true },
                    { 8, 50m, "Pickup", "Utility pickup trucks for cargo and travel", true },
                    { 9, 70m, "Van", "Passenger vans for groups and tours", true },
                    { 10, 60m, "Minivan", "Family minivans with extra space", true },
                    { 11, 65m, "Electric", "Eco-friendly electric vehicles", true },
                    { 12, 45m, "Hybrid", "Fuel-efficient hybrid cars", true },
                    { 13, 150m, "Sports", "High-performance sports cars", true },
                    { 14, 110m, "Premium SUV", "Luxury SUVs with advanced features", true },
                    { 15, 85m, "Business", "Executive cars for business travel", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "Description",
                value: "Affordable compact cars");

            migrationBuilder.UpdateData(
                table: "CarCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Description",
                value: "Premium vehicles");
        }
    }
}
