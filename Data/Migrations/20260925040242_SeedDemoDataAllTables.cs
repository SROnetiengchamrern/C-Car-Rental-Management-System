using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoDataAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Address", "BranchName", "City", "Email", "IsActive", "ManagerName", "Phone" },
                values: new object[,]
                {
                    { 3, "Port Road", "Sihanoukville Port", "Sihanoukville", "shv@carrental.local", true, "Piseth Long", "034-555-666" },
                    { 4, "1 Street 3", "Battambang City", "Battambang", "btb@carrental.local", true, "Sophea Lim", "053-777-888" },
                    { 5, "River Road", "Kampot Riverside", "Kampot", "kpt@carrental.local", true, "Ravy Sok", "033-222-111" },
                    { 6, "Street 289", "PP Toul Kork", "Phnom Penh", "tk@carrental.local", true, "Chantha Keo", "023-444-555" },
                    { 7, "Airport Blvd", "PP Airport", "Phnom Penh", "ppa@carrental.local", true, "Mony Huot", "023-666-777" },
                    { 8, "Beach Road", "Kep Beach", "Kep", "kep@carrental.local", true, "Sina Chum", "036-111-333" },
                    { 9, "Mekong Quay", "Kratie Mekong", "Kratie", "kte@carrental.local", true, "Bopha Yin", "072-444-222" },
                    { 10, "Town Center", "Banlung Highland", "Banlung", "blg@carrental.local", true, "Vicheka Phan", "075-888-999" },
                    { 11, "National Road 7", "Kompong Cham", "Kampong Cham", "kpc@carrental.local", true, "Dalin Mao", "042-123-456" },
                    { 12, "Border Road", "Pailin Border", "Pailin", "pln@carrental.local", true, "Serey Touch", "055-321-654" },
                    { 13, "Checkpoint Area", "Poipet Checkpoint", "Poipet", "ppt@carrental.local", true, "Nita Sao", "054-987-123" },
                    { 14, "National Road 2", "Takeo South", "Takeo", "tko@carrental.local", true, "Rithy Seng", "032-456-789" },
                    { 15, "Coastal Road", "Koh Kong Coast", "Koh Kong", "kk@carrental.local", true, "Sothea Em", "035-654-321" }
                });

            migrationBuilder.InsertData(
                table: "CarStatusHistory",
                columns: new[] { "HistoryId", "CarId", "ChangedAt", "ChangedByEmployeeId", "NewStatus", "Notes", "PreviousStatus", "Reason" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, "Rented", null, "Available", "Contract RC-2025-0001" },
                    { 2, 1, new DateTime(2025, 6, 5, 15, 40, 0, 0, DateTimeKind.Unspecified), 2, "Available", null, "Rented", "Returned" },
                    { 3, 2, new DateTime(2025, 7, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, "Rented", null, "Available", "Contract RC-2025-0003" },
                    { 4, 3, new DateTime(2025, 6, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, "Rented", null, "Available", "Contract RC-2025-0002" },
                    { 5, 3, new DateTime(2025, 6, 14, 14, 10, 0, 0, DateTimeKind.Unspecified), 3, "Available", null, "Rented", "Returned" }
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Status",
                value: "Rented");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BranchId", "CategoryId", "Color", "CreatedAt", "DailyRate", "FuelType", "ImageUrl", "LicensePlate", "Make", "Mileage", "Model", "Seats", "Status", "Transmission", "VIN", "Year" },
                values: new object[,]
                {
                    { 4, 1, 5, "Gray", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, "Gasoline", null, "PP-2345", "Toyota", 22100, "Camry", 5, "Available", "Automatic", "TOYCAM2023002", 2023 },
                    { 7, 2, 9, "White", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75m, "Diesel", null, "SR-3344", "Toyota", 18400, "HiAce", 12, "Available", "Manual", "TOYHIA2023001", 2023 },
                    { 9, 1, 12, "White", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48m, "Hybrid", null, "PP-8899", "Toyota", 11200, "Corolla Hybrid", 5, "Maintenance", "Automatic", "TOYCOR2024001", 2024 },
                    { 11, 2, 14, "Black", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115m, "Gasoline", null, "SR-5566", "Lexus", 6200, "RX350", 5, "Available", "Automatic", "LEXRX2024001", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CreatedAt", "DateOfBirth", "Email", "FirstName", "LastName", "LicenseExpiry", "LicenseNumber", "Phone" },
                values: new object[,]
                {
                    { 3, "12 Mao Tse Tung", "Phnom Penh", new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.nguyen@email.com", "David", "Nguyen", new DateTime(2029, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-009012", "010-555-666" },
                    { 4, "5 Beach Road", "Sihanoukville", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.lee@email.com", "Anna", "Lee", new DateTime(2028, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-003456", "010-777-888" },
                    { 5, "9 Independence St", "Battambang", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.brown@email.com", "Michael", "Brown", new DateTime(2027, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-007890", "011-111-333" },
                    { 6, "21 Riverside", "Kampot", new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophie.martin@email.com", "Sophie", "Martin", new DateTime(2029, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-002468", "011-222-444" },
                    { 7, "77 Russian Blvd", "Phnom Penh", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.wilson@email.com", "James", "Wilson", new DateTime(2028, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-008642", "011-333-555" },
                    { 8, "3 Old Market", "Siem Reap", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@email.com", "Emily", "Davis", new DateTime(2027, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-004680", "011-444-666" },
                    { 9, "66 Street 271", "Phnom Penh", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel.kim@email.com", "Daniel", "Kim", new DateTime(2029, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-006802", "012-111-777" },
                    { 10, "14 Park Avenue", "Kep", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.park@email.com", "Olivia", "Park", new DateTime(2028, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-001357", "012-222-888" },
                    { 11, "8 Bridge Street", "Kratie", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "william.taylor@email.com", "William", "Taylor", new DateTime(2027, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-009753", "012-333-999" },
                    { 12, "19 Highland Rd", "Banlung", new DateTime(2025, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "mia.garcia@email.com", "Mia", "Garcia", new DateTime(2029, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-005791", "013-111-000" },
                    { 13, "2 Checkpoint Rd", "Poipet", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas.h@email.com", "Lucas", "Hernandez", new DateTime(2028, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-003159", "013-222-111" },
                    { 14, "41 South Road", "Takeo", new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ava.lopez@email.com", "Ava", "Lopez", new DateTime(2027, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-007531", "013-333-222" },
                    { 15, "10 Coast Street", "Koh Kong", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "noah.clark@email.com", "Noah", "Clark", new DateTime(2029, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "DL-002480", "014-111-333" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BranchId", "Email", "FirstName", "HireDate", "IsActive", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { 4, 2, "malis.sok@carrental.local", "Malis", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sok", "015-444-555", "Manager", 750m },
                    { 14, 1, "sokha.meas@carrental.local", "Sokha", new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Meas", "074-567-890", "Inspector", 480m }
                });

            migrationBuilder.InsertData(
                table: "RentalContracts",
                columns: new[] { "ContractId", "BranchId", "ContractNumber", "CreatedAt", "CustomerId", "DepositAmount", "EmployeeId", "EndDate", "Notes", "StartDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, "RC-2025-0001", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 50m, 2, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "City trip", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 140m },
                    { 2, 2, "RC-2025-0002", new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 100m, 3, new DateTime(2025, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Temple tour", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 520m }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "SettingId", "Description", "GroupName", "IsActive", "SettingKey", "SettingValue", "UpdatedAt" },
                values: new object[,]
                {
                    { 7, "Head office address", "Company", true, "CompanyAddress", "123 Norodom Blvd, Phnom Penh", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Default deposit amount", "Rental", true, "DepositDefault", "50", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Minimum rental days", "Rental", true, "MinRentalDays", "1", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Maximum rental days", "Rental", true, "MaxRentalDays", "30", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Invoice number prefix", "Finance", true, "InvoicePrefix", "INV-", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Contract number prefix", "Rental", true, "ContractPrefix", "RC-", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Customer support hours", "Company", true, "SupportHours", "08:00-20:00", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Fuel return policy", "Rental", true, "FuelPolicy", "Full-to-Full", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Minimum damage fee", "Finance", true, "DamageFeeMin", "25", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CarMaintenance",
                columns: new[] { "MaintenanceId", "CarId", "Cost", "Description", "EmployeeId", "EndDate", "MaintenanceType", "Notes", "ServiceProvider", "StartDate", "Status" },
                values: new object[,]
                {
                    { 4, 3, 70m, "AC gas refill", 14, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AC Service", null, "BMW Center", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 7, 7, 200m, "Gearbox fluid change", 14, new DateTime(2025, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transmission", null, "Toyota Service", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 10, 11, 110m, "Premium oil service", 14, new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oil Change", null, "Lexus Care", new DateTime(2025, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "CarReturns",
                columns: new[] { "ReturnId", "CarId", "ContractId", "DamageFee", "EmployeeId", "FuelLevel", "LateFee", "Notes", "OdometerReading", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, 0m, 2, "Full", 0m, "Good condition", 15680, new DateTime(2025, 6, 5, 15, 30, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 2, 3, 2, 25m, 3, "3/4", 0m, "Minor scratch", 4650, new DateTime(2025, 6, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 10, 1, 2, 0m, 14, "Full", 0m, "Inspection follow-up", 15720, new DateTime(2025, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "CarStatusHistory",
                columns: new[] { "HistoryId", "CarId", "ChangedAt", "ChangedByEmployeeId", "NewStatus", "Notes", "PreviousStatus", "Reason" },
                values: new object[,]
                {
                    { 13, 7, new DateTime(2025, 6, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 4, "Rented", null, "Available", "Contract RC-2025-0008" },
                    { 14, 7, new DateTime(2025, 6, 25, 17, 20, 0, 0, DateTimeKind.Unspecified), 4, "Available", null, "Rented", "Returned" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BranchId", "CategoryId", "Color", "CreatedAt", "DailyRate", "FuelType", "ImageUrl", "LicensePlate", "Make", "Mileage", "Model", "Seats", "Status", "Transmission", "VIN", "Year" },
                values: new object[,]
                {
                    { 5, 6, 6, "Red", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, "Gasoline", null, "PP-3456", "Mazda", 30500, "2", 5, "Available", "Automatic", "MAZ22022001", 2022 },
                    { 6, 3, 8, "Blue", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, "Diesel", null, "SHV-1122", "Ford", 9600, "Ranger", 5, "Available", "Automatic", "FORRAN2024001", 2024 },
                    { 8, 7, 11, "Green", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68m, "Electric", null, "PP-7788", "BYD", 5300, "Atto 3", 5, "Available", "Automatic", "BYDATT2024001", 2024 },
                    { 10, 7, 13, "Yellow", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 160m, "Gasoline", null, "PP-9900", "Ford", 7800, "Mustang", 4, "Available", "Automatic", "FORMUS2023001", 2023 },
                    { 12, 6, 15, "Silver", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90m, "Gasoline", null, "PP-6677", "Mercedes", 14100, "E200", 5, "Available", "Automatic", "MERE2002023001", 2023 },
                    { 13, 4, 4, "Orange", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24m, "Gasoline", null, "BTB-1212", "Suzuki", 26800, "Swift", 5, "Available", "Manual", "SUZSWI2022001", 2022 },
                    { 14, 5, 10, "Gray", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62m, "Gasoline", null, "KPT-3434", "Toyota", 17500, "Avanza", 7, "Rented", "Automatic", "TOYAVA2023001", 2023 },
                    { 15, 8, 7, "Red", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98m, "Gasoline", null, "KEP-5656", "Mazda", 3500, "MX-5", 2, "Available", "Automatic", "MAZMX52024001", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BranchId", "Email", "FirstName", "HireDate", "IsActive", "LastName", "Phone", "Position", "Salary" },
                values: new object[,]
                {
                    { 5, 3, "vuthy.chea@carrental.local", "Vuthy", new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chea", "016-111-222", "Staff", 420m },
                    { 6, 3, "sreymom.heng@carrental.local", "Sreymom", new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Heng", "016-333-444", "Cashier", 400m },
                    { 7, 4, "kunthea.phal@carrental.local", "Kunthea", new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Phal", "017-555-666", "Staff", 430m },
                    { 8, 5, "bora.nhim@carrental.local", "Bora", new DateTime(2022, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nhim", "018-777-888", "Technician", 500m },
                    { 9, 6, "chenda.oum@carrental.local", "Chenda", new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Oum", "019-999-000", "Staff", 440m },
                    { 10, 7, "pisey.ly@carrental.local", "Pisey", new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ly", "070-123-456", "Manager", 780m },
                    { 11, 8, "ravy.tep@carrental.local", "Ravy", new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tep", "071-234-567", "Staff", 410m },
                    { 12, 9, "sopheap.kang@carrental.local", "Sopheap", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kang", "072-345-678", "Staff", 415m },
                    { 13, 10, "nary.um@carrental.local", "Nary", new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Um", "073-456-789", "Cashier", 390m },
                    { 15, 7, "vicheka.san@carrental.local", "Vicheka", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San", "076-678-901", "Staff", 420m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "ContractId", "Notes", "PaymentDate", "PaymentMethod", "ReceivedByEmployeeId", "Status", "TransactionReference" },
                values: new object[,]
                {
                    { 1, 50m, 1, "Deposit", new DateTime(2025, 5, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 2, "Completed", "CASH-001" },
                    { 2, 140m, 1, "Final payment", new DateTime(2025, 6, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "Card", 2, "Completed", "CARD-1001" },
                    { 3, 100m, 2, "Deposit", new DateTime(2025, 6, 8, 9, 30, 0, 0, DateTimeKind.Unspecified), "Cash", 3, "Completed", "CASH-002" },
                    { 4, 520m, 2, null, new DateTime(2025, 6, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Transfer", 4, "Completed", "TRF-2002" }
                });

            migrationBuilder.InsertData(
                table: "RentalContractDetails",
                columns: new[] { "DetailId", "CarId", "ContractId", "DailyRate", "Days", "Notes", "SubTotal" },
                values: new object[,]
                {
                    { 1, 1, 1, 28m, 5, null, 140m },
                    { 2, 3, 2, 130m, 4, null, 520m }
                });

            migrationBuilder.InsertData(
                table: "RentalContracts",
                columns: new[] { "ContractId", "BranchId", "ContractNumber", "CreatedAt", "CustomerId", "DepositAmount", "EmployeeId", "EndDate", "Notes", "StartDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 3, 1, "RC-2025-0003", new DateTime(2025, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 80m, 2, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business week", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", 360m },
                    { 8, 2, "RC-2025-0008", new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 90m, 4, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Group van", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 375m },
                    { 13, 1, "RC-2025-0013", new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 150m, 2, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long rental", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", 900m },
                    { 14, 1, "RC-2025-0014", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 30m, 1, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 80m }
                });

            migrationBuilder.InsertData(
                table: "CarMaintenance",
                columns: new[] { "MaintenanceId", "CarId", "Cost", "Description", "EmployeeId", "EndDate", "MaintenanceType", "Notes", "ServiceProvider", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 9, 80m, "Hybrid system oil service", 8, new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oil Change", null, "Toyota Service", new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "InProgress" },
                    { 2, 1, 35m, "Rotate and balance tires", 8, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tire Rotation", null, "Local Garage", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 3, 2, 50m, "Inspect brake pads", 8, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brake Check", null, "Honda Care", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 5, 4, 120m, "Replace battery", 8, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Battery", null, "Toyota Service", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 6, 6, 150m, "Diesel injector cleaning", 8, new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engine Tune", null, "Ford Workshop", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 8, 8, 0m, "EV firmware update", 8, null, "Software Update", "Next week", "BYD Service", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled" },
                    { 9, 10, 90m, "Full exterior polish", 8, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Detailing", null, "Premium Detail", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 11, 12, 45m, "Annual safety inspection", 8, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inspection", null, "Mercedes Center", new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 12, 13, 180m, "Clutch adjustment", 8, new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clutch", null, "Suzuki Shop", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 13, 14, 40m, "Coolant flush", 14, new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coolant", null, "Local Garage", new DateTime(2025, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 14, 15, 55m, "Wheel alignment", 8, null, "Alignment", null, "Mazda Service", new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled" },
                    { 15, 5, 45m, "Regular oil change", 8, null, "Oil Change", null, "Mazda Service", new DateTime(2025, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scheduled" }
                });

            migrationBuilder.InsertData(
                table: "CarReturns",
                columns: new[] { "ReturnId", "CarId", "ContractId", "DamageFee", "EmployeeId", "FuelLevel", "LateFee", "Notes", "OdometerReading", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 5, 7, 8, 0m, 4, "Full", 0m, null, 19100, new DateTime(2025, 6, 25, 17, 10, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 8, 4, 14, 0m, 1, "Full", 0m, null, 22340, new DateTime(2025, 5, 10, 10, 15, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 9, 5, 1, 0m, 14, "Full", 0m, "Extra car return", 30700, new DateTime(2025, 6, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 13, 3, 8, 0m, 3, "Full", 0m, null, 4700, new DateTime(2025, 6, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "CarStatusHistory",
                columns: new[] { "HistoryId", "CarId", "ChangedAt", "ChangedByEmployeeId", "NewStatus", "Notes", "PreviousStatus", "Reason" },
                values: new object[,]
                {
                    { 6, 9, new DateTime(2025, 7, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), 8, "Maintenance", null, "Available", "Oil change" },
                    { 7, 14, new DateTime(2025, 7, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 8, "Rented", null, "Available", "Contract RC-2025-0006" },
                    { 8, 6, new DateTime(2025, 7, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), 5, "Rented", null, "Available", "Contract RC-2025-0004" },
                    { 9, 8, new DateTime(2025, 7, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 10, "Rented", null, "Available", "Contract RC-2025-0009" },
                    { 10, 10, new DateTime(2025, 7, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), 15, "Rented", null, "Available", "Contract RC-2025-0015" },
                    { 11, 5, new DateTime(2025, 4, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 9, "Rented", null, "Available", "Contract RC-2025-0007" },
                    { 12, 5, new DateTime(2025, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 9, "Available", null, "Rented", "Returned" },
                    { 15, 15, new DateTime(2025, 5, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), 11, "Rented", null, "Available", "Contract RC-2025-0010" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "ContractId", "Notes", "PaymentDate", "PaymentMethod", "ReceivedByEmployeeId", "Status", "TransactionReference" },
                values: new object[,]
                {
                    { 5, 80m, 3, "Deposit", new DateTime(2025, 6, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), "Card", 2, "Completed", "CARD-1003" },
                    { 10, 465m, 8, "Deposit + balance", new DateTime(2025, 6, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), "Card", 4, "Completed", "CARD-1008" },
                    { 14, 150m, 13, "Deposit", new DateTime(2025, 6, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), "Transfer", 2, "Completed", "TRF-2013" }
                });

            migrationBuilder.InsertData(
                table: "RentalContractDetails",
                columns: new[] { "DetailId", "CarId", "ContractId", "DailyRate", "Days", "Notes", "SubTotal" },
                values: new object[,]
                {
                    { 3, 2, 3, 60m, 6, null, 360m },
                    { 8, 7, 8, 75m, 5, null, 375m },
                    { 12, 12, 13, 90m, 10, null, 900m },
                    { 13, 4, 14, 40m, 2, null, 80m },
                    { 15, 5, 1, 30m, 2, "Extra day hatchback", 60m }
                });

            migrationBuilder.InsertData(
                table: "RentalContracts",
                columns: new[] { "ContractId", "BranchId", "ContractNumber", "CreatedAt", "CustomerId", "DepositAmount", "EmployeeId", "EndDate", "Notes", "StartDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 4, 3, "RC-2025-0004", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 60m, 5, new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beach weekend", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", 165m },
                    { 5, 4, "RC-2025-0005", new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 40m, 7, new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 96m },
                    { 6, 5, "RC-2025-0006", new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 70m, 8, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family trip", new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", 310m },
                    { 7, 6, "RC-2025-0007", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 50m, 9, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 120m },
                    { 9, 7, "RC-2025-0009", new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 50m, 10, new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Airport pickup", new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", 136m },
                    { 10, 8, "RC-2025-0010", new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 80m, 11, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Convertible weekend", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 196m },
                    { 11, 9, "RC-2025-0011", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 0m, 12, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer cancelled", new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 0m },
                    { 12, 10, "RC-2025-0012", new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 60m, 13, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 180m },
                    { 15, 7, "RC-2025-0015", new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 120m, 15, new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports car", new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", 640m }
                });

            migrationBuilder.InsertData(
                table: "ReturnInspections",
                columns: new[] { "InspectionId", "DamageDescription", "EstimatedRepairCost", "ExteriorCondition", "HasDamage", "InspectedByEmployeeId", "InspectionDate", "InteriorCondition", "Notes", "ReturnId" },
                values: new object[,]
                {
                    { 1, null, 0m, "Good", false, 14, new DateTime(2025, 6, 5, 15, 45, 0, 0, DateTimeKind.Unspecified), "Good", null, 1 },
                    { 2, "Left door scratch", 25m, "Fair", true, 14, new DateTime(2025, 6, 14, 14, 20, 0, 0, DateTimeKind.Unspecified), "Good", "Charged to customer", 2 },
                    { 10, null, 0m, "Good", false, 8, new DateTime(2025, 6, 14, 15, 20, 0, 0, DateTimeKind.Unspecified), "Good", null, 10 }
                });

            migrationBuilder.InsertData(
                table: "CarReturns",
                columns: new[] { "ReturnId", "CarId", "ContractId", "DamageFee", "EmployeeId", "FuelLevel", "LateFee", "Notes", "OdometerReading", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 3, 13, 5, 0m, 7, "Full", 0m, null, 27100, new DateTime(2025, 5, 4, 16, 20, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 4, 5, 7, 0m, 9, "Half", 15m, "1 hour late", 30950, new DateTime(2025, 4, 15, 11, 45, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 6, 15, 10, 0m, 11, "Full", 0m, "Excellent", 3720, new DateTime(2025, 5, 22, 18, 30, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 7, 11, 12, 40m, 13, "3/4", 0m, "Bumper mark", 6480, new DateTime(2025, 6, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 11, 1, 5, 10m, 2, "Full", 0m, "Cleaning fee", 15750, new DateTime(2025, 5, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 12, 4, 7, 0m, 9, "3/4", 0m, null, 22400, new DateTime(2025, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 14, 8, 10, 0m, 10, "Full", 0m, null, 5450, new DateTime(2025, 5, 22, 19, 30, 0, 0, DateTimeKind.Unspecified), "Completed" },
                    { 15, 13, 12, 0m, 7, "Half", 15m, "Late return", 27220, new DateTime(2025, 6, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "ContractId", "Notes", "PaymentDate", "PaymentMethod", "ReceivedByEmployeeId", "Status", "TransactionReference" },
                values: new object[,]
                {
                    { 6, 60m, 4, "Deposit", new DateTime(2025, 7, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 5, "Completed", "CASH-004" },
                    { 7, 136m, 5, "Full payment", new DateTime(2025, 5, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 7, "Completed", "CASH-005" },
                    { 8, 70m, 6, "Deposit", new DateTime(2025, 7, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), "Card", 8, "Completed", "CARD-1006" },
                    { 9, 170m, 7, null, new DateTime(2025, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), "Transfer", 9, "Completed", "TRF-2007" },
                    { 11, 50m, 9, "Deposit", new DateTime(2025, 7, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 10, "Completed", "CASH-009" },
                    { 12, 276m, 10, null, new DateTime(2025, 5, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), "Card", 11, "Completed", "CARD-1010" },
                    { 13, 240m, 12, null, new DateTime(2025, 6, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 13, "Completed", "CASH-012" },
                    { 15, 120m, 15, "Deposit", new DateTime(2025, 7, 6, 16, 0, 0, 0, DateTimeKind.Unspecified), "Card", 15, "Completed", "CARD-1015" }
                });

            migrationBuilder.InsertData(
                table: "RentalContractDetails",
                columns: new[] { "DetailId", "CarId", "ContractId", "DailyRate", "Days", "Notes", "SubTotal" },
                values: new object[,]
                {
                    { 4, 6, 4, 55m, 3, null, 165m },
                    { 5, 13, 5, 24m, 4, null, 96m },
                    { 6, 14, 6, 62m, 5, null, 310m },
                    { 7, 5, 7, 30m, 4, null, 120m },
                    { 9, 8, 9, 68m, 2, null, 136m },
                    { 10, 15, 10, 98m, 2, null, 196m },
                    { 11, 11, 12, 90m, 2, "Adjusted rate", 180m },
                    { 14, 10, 15, 160m, 4, null, 640m }
                });

            migrationBuilder.InsertData(
                table: "ReturnInspections",
                columns: new[] { "InspectionId", "DamageDescription", "EstimatedRepairCost", "ExteriorCondition", "HasDamage", "InspectedByEmployeeId", "InspectionDate", "InteriorCondition", "Notes", "ReturnId" },
                values: new object[,]
                {
                    { 5, null, 0m, "Good", false, 8, new DateTime(2025, 6, 25, 17, 30, 0, 0, DateTimeKind.Unspecified), "Good", null, 5 },
                    { 8, null, 0m, "Good", false, 14, new DateTime(2025, 5, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), "Good", null, 8 },
                    { 9, null, 0m, "Good", false, 14, new DateTime(2025, 6, 5, 16, 15, 0, 0, DateTimeKind.Unspecified), "Good", null, 9 },
                    { 13, null, 0m, "Good", false, 14, new DateTime(2025, 6, 25, 18, 20, 0, 0, DateTimeKind.Unspecified), "Good", null, 13 },
                    { 3, null, 0m, "Good", false, 8, new DateTime(2025, 5, 4, 16, 40, 0, 0, DateTimeKind.Unspecified), "Good", null, 3 },
                    { 4, null, 0m, "Good", false, 14, new DateTime(2025, 4, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), "Fair", "Needs interior clean", 4 },
                    { 6, null, 0m, "Excellent", false, 14, new DateTime(2025, 5, 22, 18, 45, 0, 0, DateTimeKind.Unspecified), "Excellent", null, 6 },
                    { 7, "Rear bumper mark", 40m, "Fair", true, 8, new DateTime(2025, 6, 3, 12, 20, 0, 0, DateTimeKind.Unspecified), "Good", null, 7 },
                    { 11, null, 10m, "Good", false, 14, new DateTime(2025, 5, 4, 17, 15, 0, 0, DateTimeKind.Unspecified), "Fair", "Cleaning only", 11 },
                    { 12, null, 0m, "Good", false, 8, new DateTime(2025, 4, 15, 13, 20, 0, 0, DateTimeKind.Unspecified), "Good", null, 12 },
                    { 14, null, 0m, "Good", false, 8, new DateTime(2025, 5, 22, 19, 45, 0, 0, DateTimeKind.Unspecified), "Good", null, 14 },
                    { 15, null, 0m, "Good", false, 14, new DateTime(2025, 6, 3, 14, 20, 0, 0, DateTimeKind.Unspecified), "Good", "Late but ok", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarMaintenance",
                keyColumn: "MaintenanceId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarStatusHistory",
                keyColumn: "HistoryId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RentalContractDetails",
                keyColumn: "DetailId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReturnInspections",
                keyColumn: "InspectionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "SettingId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarReturns",
                keyColumn: "ReturnId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RentalContracts",
                keyColumn: "ContractId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                column: "Status",
                value: "Available");
        }
    }
}
