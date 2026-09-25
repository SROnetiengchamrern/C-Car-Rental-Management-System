using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "CarCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BaseDailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LicenseExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_CarCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CarCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalContracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalContracts", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_RentalContracts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalContracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalContracts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarMaintenance",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    MaintenanceType = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ServiceProvider = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMaintenance", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_CarMaintenance_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarMaintenance_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CarStatusHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PreviousStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NewStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarStatusHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_CarStatusHistory_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarStatusHistory_Employees_ChangedByEmployeeId",
                        column: x => x.ChangedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CarReturns",
                columns: table => new
                {
                    ReturnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdometerReading = table.Column<int>(type: "int", nullable: false),
                    FuelLevel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LateFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DamageFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReturns", x => x.ReturnId);
                    table.ForeignKey(
                        name: "FK_CarReturns_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarReturns_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarReturns_RentalContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "RentalContracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TransactionReference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ReceivedByEmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Employees_ReceivedByEmployeeId",
                        column: x => x.ReceivedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Payments_RentalContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "RentalContracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentalContractDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    DailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalContractDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_RentalContractDetails_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentalContractDetails_RentalContracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "RentalContracts",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReturnInspections",
                columns: table => new
                {
                    InspectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnId = table.Column<int>(type: "int", nullable: false),
                    InspectedByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExteriorCondition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InteriorCondition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HasDamage = table.Column<bool>(type: "bit", nullable: false),
                    DamageDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EstimatedRepairCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnInspections", x => x.InspectionId);
                    table.ForeignKey(
                        name: "FK_ReturnInspections_CarReturns_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "CarReturns",
                        principalColumn: "ReturnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnInspections_Employees_InspectedByEmployeeId",
                        column: x => x.InspectedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Address", "BranchName", "City", "Email", "IsActive", "ManagerName", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Norodom Blvd", "Phnom Penh Central", "Phnom Penh", "pp@carrental.local", true, "Sokha Meas", "023-111-222" },
                    { 2, "Airport Road", "Siem Reap Airport", "Siem Reap", "sr@carrental.local", true, "Vannak Chhim", "063-333-444" }
                });

            migrationBuilder.InsertData(
                table: "CarCategories",
                columns: new[] { "CategoryId", "BaseDailyRate", "CategoryName", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, 25m, "Economy", "Affordable compact cars", true },
                    { 2, 55m, "SUV", "Family and adventure SUVs", true },
                    { 3, 120m, "Luxury", "Premium vehicles", true }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CreatedAt", "DateOfBirth", "Email", "FirstName", "LastName", "LicenseExpiry", "LicenseNumber", "Phone" },
                values: new object[,]
                {
                    { 1, "45 Street 51", "Phnom Penh", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.smith@email.com", "John", "Smith", new DateTime(2028, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-001234", "010-111-222" },
                    { 2, "88 Pub Street", "Siem Reap", new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa.chan@email.com", "Lisa", "Chan", new DateTime(2027, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-005678", "010-333-444" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BranchId", "CategoryId", "Color", "CreatedAt", "DailyRate", "FuelType", "ImageUrl", "LicensePlate", "Make", "Mileage", "Model", "Seats", "Status", "Transmission", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, "White", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28m, "Gasoline", null, "PP-1234", "Toyota", 15200, "Vios", 5, "Available", "Automatic", "TOYVIO2023001", 2023 },
                    { 2, 1, 2, "Black", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, "Gasoline", null, "PP-5678", "Honda", 8200, "CR-V", 5, "Available", "Automatic", "HONCRV2024001", 2024 },
                    { 3, 2, 3, "Silver", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130m, "Gasoline", null, "SR-9012", "BMW", 4100, "520i", 5, "Available", "Automatic", "BMW5202024001", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BranchId", "Email", "FirstName", "HireDate", "IsActive", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "dara.kim@carrental.local", "Dara", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kim", "012-345-678", "Manager", 800m },
                    { 2, 1, "srey.nin@carrental.local", "Srey", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nin", "012-987-654", "Staff", 450m },
                    { 3, 2, "rith.pov@carrental.local", "Rith", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pov", "015-222-333", "Staff", 450m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarMaintenance_CarId",
                table: "CarMaintenance",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarMaintenance_EmployeeId",
                table: "CarMaintenance",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReturns_CarId",
                table: "CarReturns",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReturns_ContractId",
                table: "CarReturns",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReturns_EmployeeId",
                table: "CarReturns",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BranchId",
                table: "Cars",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_LicensePlate",
                table: "Cars",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarStatusHistory_CarId",
                table: "CarStatusHistory",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarStatusHistory_ChangedByEmployeeId",
                table: "CarStatusHistory",
                column: "ChangedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LicenseNumber",
                table: "Customers",
                column: "LicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchId",
                table: "Employees",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ContractId",
                table: "Payments",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ReceivedByEmployeeId",
                table: "Payments",
                column: "ReceivedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContractDetails_CarId",
                table: "RentalContractDetails",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContractDetails_ContractId",
                table: "RentalContractDetails",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_BranchId",
                table: "RentalContracts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_ContractNumber",
                table: "RentalContracts",
                column: "ContractNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_CustomerId",
                table: "RentalContracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_EmployeeId",
                table: "RentalContracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnInspections_InspectedByEmployeeId",
                table: "ReturnInspections",
                column: "InspectedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnInspections_ReturnId",
                table: "ReturnInspections",
                column: "ReturnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarMaintenance");

            migrationBuilder.DropTable(
                name: "CarStatusHistory");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RentalContractDetails");

            migrationBuilder.DropTable(
                name: "ReturnInspections");

            migrationBuilder.DropTable(
                name: "CarReturns");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RentalContracts");

            migrationBuilder.DropTable(
                name: "CarCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
