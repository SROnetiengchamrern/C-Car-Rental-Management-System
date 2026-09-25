using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTotalSubtractDepositAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 1,
                column: "TotalAmount",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 2,
                column: "TotalAmount",
                value: 400m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 3,
                column: "TotalAmount",
                value: 280m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 4,
                column: "TotalAmount",
                value: 105m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 5,
                column: "TotalAmount",
                value: 56m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 6,
                column: "TotalAmount",
                value: 240m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 7,
                column: "TotalAmount",
                value: 70m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 8,
                column: "TotalAmount",
                value: 285m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 9,
                column: "TotalAmount",
                value: 76m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 10,
                column: "TotalAmount",
                value: 116m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 12,
                column: "TotalAmount",
                value: 120m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 13,
                column: "TotalAmount",
                value: 750m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 14,
                column: "TotalAmount",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 15,
                column: "TotalAmount",
                value: 480m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 1,
                column: "TotalAmount",
                value: 250m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 2,
                column: "TotalAmount",
                value: 600m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 3,
                column: "TotalAmount",
                value: 440m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 4,
                column: "TotalAmount",
                value: 225m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 5,
                column: "TotalAmount",
                value: 136m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 6,
                column: "TotalAmount",
                value: 380m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 7,
                column: "TotalAmount",
                value: 170m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 8,
                column: "TotalAmount",
                value: 465m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 9,
                column: "TotalAmount",
                value: 176m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 10,
                column: "TotalAmount",
                value: 276m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 12,
                column: "TotalAmount",
                value: 240m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 13,
                column: "TotalAmount",
                value: 1050m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 14,
                column: "TotalAmount",
                value: 110m);

            migrationBuilder.UpdateData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 15,
                column: "TotalAmount",
                value: 720m);
        }
    }
}
