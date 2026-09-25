using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddContractDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "RentalContracts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 1,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 2,
                columns: new[] { "DiscountAmount", "TotalAmount" },
                values: new object[] { 20m, 500m });

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 3,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 4,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 5,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 6,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 7,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 8,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 9,
                columns: new[] { "DiscountAmount", "TotalAmount" },
                values: new object[] { 10m, 126m });

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 10,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 11,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 12,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 13,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 14,
                column: "DiscountAmount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 15,
                columns: new[] { "DiscountAmount", "TotalAmount" },
                values: new object[] { 40m, 600m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "RentalContracts");

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 2,
                column: "TotalAmount",
                value: 520m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 9,
                column: "TotalAmount",
                value: 136m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 15,
                column: "TotalAmount",
                value: 640m);
        }
    }
}
