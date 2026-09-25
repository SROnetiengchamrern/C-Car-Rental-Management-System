using CarRentalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Data;

public static class DemoSeedData
{
    private static readonly DateTime SeedDate = new(2025, 1, 1);

    public static void Apply(ModelBuilder modelBuilder)
    {
        SeedBranches(modelBuilder);
        SeedEmployees(modelBuilder);
        SeedCustomers(modelBuilder);
        SeedCars(modelBuilder);
        SeedContracts(modelBuilder);
        SeedContractDetails(modelBuilder);
        SeedPayments(modelBuilder);
        SeedReturns(modelBuilder);
        SeedInspections(modelBuilder);
        SeedMaintenance(modelBuilder);
        SeedStatusHistory(modelBuilder);
        SeedSettings(modelBuilder);
    }

    private static void SeedBranches(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>().HasData(
            new Branch { BranchId = 1, BranchName = "Phnom Penh Central", Address = "123 Norodom Blvd", City = "Phnom Penh", Phone = "023-111-222", Email = "pp@carrental.local", ManagerName = "Sokha Meas", IsActive = true },
            new Branch { BranchId = 2, BranchName = "Siem Reap Airport", Address = "Airport Road", City = "Siem Reap", Phone = "063-333-444", Email = "sr@carrental.local", ManagerName = "Vannak Chhim", IsActive = true },
            new Branch { BranchId = 3, BranchName = "Sihanoukville Port", Address = "Port Road", City = "Sihanoukville", Phone = "034-555-666", Email = "shv@carrental.local", ManagerName = "Piseth Long", IsActive = true },
            new Branch { BranchId = 4, BranchName = "Battambang City", Address = "1 Street 3", City = "Battambang", Phone = "053-777-888", Email = "btb@carrental.local", ManagerName = "Sophea Lim", IsActive = true },
            new Branch { BranchId = 5, BranchName = "Kampot Riverside", Address = "River Road", City = "Kampot", Phone = "033-222-111", Email = "kpt@carrental.local", ManagerName = "Ravy Sok", IsActive = true },
            new Branch { BranchId = 6, BranchName = "PP Toul Kork", Address = "Street 289", City = "Phnom Penh", Phone = "023-444-555", Email = "tk@carrental.local", ManagerName = "Chantha Keo", IsActive = true },
            new Branch { BranchId = 7, BranchName = "PP Airport", Address = "Airport Blvd", City = "Phnom Penh", Phone = "023-666-777", Email = "ppa@carrental.local", ManagerName = "Mony Huot", IsActive = true },
            new Branch { BranchId = 8, BranchName = "Kep Beach", Address = "Beach Road", City = "Kep", Phone = "036-111-333", Email = "kep@carrental.local", ManagerName = "Sina Chum", IsActive = true },
            new Branch { BranchId = 9, BranchName = "Kratie Mekong", Address = "Mekong Quay", City = "Kratie", Phone = "072-444-222", Email = "kte@carrental.local", ManagerName = "Bopha Yin", IsActive = true },
            new Branch { BranchId = 10, BranchName = "Banlung Highland", Address = "Town Center", City = "Banlung", Phone = "075-888-999", Email = "blg@carrental.local", ManagerName = "Vicheka Phan", IsActive = true },
            new Branch { BranchId = 11, BranchName = "Kompong Cham", Address = "National Road 7", City = "Kampong Cham", Phone = "042-123-456", Email = "kpc@carrental.local", ManagerName = "Dalin Mao", IsActive = true },
            new Branch { BranchId = 12, BranchName = "Pailin Border", Address = "Border Road", City = "Pailin", Phone = "055-321-654", Email = "pln@carrental.local", ManagerName = "Serey Touch", IsActive = true },
            new Branch { BranchId = 13, BranchName = "Poipet Checkpoint", Address = "Checkpoint Area", City = "Poipet", Phone = "054-987-123", Email = "ppt@carrental.local", ManagerName = "Nita Sao", IsActive = true },
            new Branch { BranchId = 14, BranchName = "Takeo South", Address = "National Road 2", City = "Takeo", Phone = "032-456-789", Email = "tko@carrental.local", ManagerName = "Rithy Seng", IsActive = true },
            new Branch { BranchId = 15, BranchName = "Koh Kong Coast", Address = "Coastal Road", City = "Koh Kong", Phone = "035-654-321", Email = "kk@carrental.local", ManagerName = "Sothea Em", IsActive = true });
    }

    private static void SeedEmployees(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, BranchId = 1, FirstName = "Dara", LastName = "Kim", Email = "dara.kim@carrental.local", Phone = "012-345-678", Position = "Manager", HireDate = new DateTime(2023, 1, 15), Salary = 800m, IsActive = true },
            new Employee { EmployeeId = 2, BranchId = 1, FirstName = "Srey", LastName = "Nin", Email = "srey.nin@carrental.local", Phone = "012-987-654", Position = "Staff", HireDate = new DateTime(2024, 3, 1), Salary = 450m, IsActive = true },
            new Employee { EmployeeId = 3, BranchId = 2, FirstName = "Rith", LastName = "Pov", Email = "rith.pov@carrental.local", Phone = "015-222-333", Position = "Staff", HireDate = new DateTime(2024, 6, 10), Salary = 450m, IsActive = true },
            new Employee { EmployeeId = 4, BranchId = 2, FirstName = "Malis", LastName = "Sok", Email = "malis.sok@carrental.local", Phone = "015-444-555", Position = "Manager", HireDate = new DateTime(2023, 5, 20), Salary = 750m, IsActive = true },
            new Employee { EmployeeId = 5, BranchId = 3, FirstName = "Vuthy", LastName = "Chea", Email = "vuthy.chea@carrental.local", Phone = "016-111-222", Position = "Staff", HireDate = new DateTime(2024, 1, 8), Salary = 420m, IsActive = true },
            new Employee { EmployeeId = 6, BranchId = 3, FirstName = "Sreymom", LastName = "Heng", Email = "sreymom.heng@carrental.local", Phone = "016-333-444", Position = "Cashier", HireDate = new DateTime(2024, 8, 12), Salary = 400m, IsActive = true },
            new Employee { EmployeeId = 7, BranchId = 4, FirstName = "Kunthea", LastName = "Phal", Email = "kunthea.phal@carrental.local", Phone = "017-555-666", Position = "Staff", HireDate = new DateTime(2023, 11, 2), Salary = 430m, IsActive = true },
            new Employee { EmployeeId = 8, BranchId = 5, FirstName = "Bora", LastName = "Nhim", Email = "bora.nhim@carrental.local", Phone = "018-777-888", Position = "Technician", HireDate = new DateTime(2022, 9, 18), Salary = 500m, IsActive = true },
            new Employee { EmployeeId = 9, BranchId = 6, FirstName = "Chenda", LastName = "Oum", Email = "chenda.oum@carrental.local", Phone = "019-999-000", Position = "Staff", HireDate = new DateTime(2024, 4, 25), Salary = 440m, IsActive = true },
            new Employee { EmployeeId = 10, BranchId = 7, FirstName = "Pisey", LastName = "Ly", Email = "pisey.ly@carrental.local", Phone = "070-123-456", Position = "Manager", HireDate = new DateTime(2023, 2, 14), Salary = 780m, IsActive = true },
            new Employee { EmployeeId = 11, BranchId = 8, FirstName = "Ravy", LastName = "Tep", Email = "ravy.tep@carrental.local", Phone = "071-234-567", Position = "Staff", HireDate = new DateTime(2024, 7, 7), Salary = 410m, IsActive = true },
            new Employee { EmployeeId = 12, BranchId = 9, FirstName = "Sopheap", LastName = "Kang", Email = "sopheap.kang@carrental.local", Phone = "072-345-678", Position = "Staff", HireDate = new DateTime(2024, 9, 1), Salary = 415m, IsActive = true },
            new Employee { EmployeeId = 13, BranchId = 10, FirstName = "Nary", LastName = "Um", Email = "nary.um@carrental.local", Phone = "073-456-789", Position = "Cashier", HireDate = new DateTime(2023, 12, 11), Salary = 390m, IsActive = true },
            new Employee { EmployeeId = 14, BranchId = 1, FirstName = "Sokha", LastName = "Meas", Email = "sokha.meas@carrental.local", Phone = "074-567-890", Position = "Inspector", HireDate = new DateTime(2022, 6, 30), Salary = 480m, IsActive = true },
            new Employee { EmployeeId = 15, BranchId = 7, FirstName = "Vicheka", LastName = "San", Email = "vicheka.san@carrental.local", Phone = "076-678-901", Position = "Staff", HireDate = new DateTime(2025, 1, 5), Salary = 420m, IsActive = true });
    }

    private static void SeedCustomers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "John", LastName = "Smith", Email = "john.smith@email.com", Phone = "010-111-222", Address = "45 Street 51", City = "Phnom Penh", LicenseNumber = "DL-001234", LicenseExpiry = new DateTime(2028, 5, 20), DateOfBirth = new DateTime(1990, 4, 12), CreatedAt = new DateTime(2025, 1, 10) },
            new Customer { CustomerId = 2, FirstName = "Lisa", LastName = "Chan", Email = "lisa.chan@email.com", Phone = "010-333-444", Address = "88 Pub Street", City = "Siem Reap", LicenseNumber = "DL-005678", LicenseExpiry = new DateTime(2027, 11, 8), DateOfBirth = new DateTime(1995, 8, 3), CreatedAt = new DateTime(2025, 2, 5) },
            new Customer { CustomerId = 3, FirstName = "David", LastName = "Nguyen", Email = "david.nguyen@email.com", Phone = "010-555-666", Address = "12 Mao Tse Tung", City = "Phnom Penh", LicenseNumber = "DL-009012", LicenseExpiry = new DateTime(2029, 1, 15), DateOfBirth = new DateTime(1988, 2, 22), CreatedAt = new DateTime(2025, 2, 12) },
            new Customer { CustomerId = 4, FirstName = "Anna", LastName = "Lee", Email = "anna.lee@email.com", Phone = "010-777-888", Address = "5 Beach Road", City = "Sihanoukville", LicenseNumber = "DL-003456", LicenseExpiry = new DateTime(2028, 9, 1), DateOfBirth = new DateTime(1992, 7, 19), CreatedAt = new DateTime(2025, 3, 1) },
            new Customer { CustomerId = 5, FirstName = "Michael", LastName = "Brown", Email = "michael.brown@email.com", Phone = "011-111-333", Address = "9 Independence St", City = "Battambang", LicenseNumber = "DL-007890", LicenseExpiry = new DateTime(2027, 6, 30), DateOfBirth = new DateTime(1985, 12, 5), CreatedAt = new DateTime(2025, 3, 8) },
            new Customer { CustomerId = 6, FirstName = "Sophie", LastName = "Martin", Email = "sophie.martin@email.com", Phone = "011-222-444", Address = "21 Riverside", City = "Kampot", LicenseNumber = "DL-002468", LicenseExpiry = new DateTime(2029, 3, 12), DateOfBirth = new DateTime(1997, 1, 28), CreatedAt = new DateTime(2025, 3, 15) },
            new Customer { CustomerId = 7, FirstName = "James", LastName = "Wilson", Email = "james.wilson@email.com", Phone = "011-333-555", Address = "77 Russian Blvd", City = "Phnom Penh", LicenseNumber = "DL-008642", LicenseExpiry = new DateTime(2028, 2, 18), DateOfBirth = new DateTime(1991, 9, 9), CreatedAt = new DateTime(2025, 4, 2) },
            new Customer { CustomerId = 8, FirstName = "Emily", LastName = "Davis", Email = "emily.davis@email.com", Phone = "011-444-666", Address = "3 Old Market", City = "Siem Reap", LicenseNumber = "DL-004680", LicenseExpiry = new DateTime(2027, 12, 25), DateOfBirth = new DateTime(1994, 5, 14), CreatedAt = new DateTime(2025, 4, 10) },
            new Customer { CustomerId = 9, FirstName = "Daniel", LastName = "Kim", Email = "daniel.kim@email.com", Phone = "012-111-777", Address = "66 Street 271", City = "Phnom Penh", LicenseNumber = "DL-006802", LicenseExpiry = new DateTime(2029, 7, 7), DateOfBirth = new DateTime(1989, 11, 3), CreatedAt = new DateTime(2025, 4, 18) },
            new Customer { CustomerId = 10, FirstName = "Olivia", LastName = "Park", Email = "olivia.park@email.com", Phone = "012-222-888", Address = "14 Park Avenue", City = "Kep", LicenseNumber = "DL-001357", LicenseExpiry = new DateTime(2028, 8, 22), DateOfBirth = new DateTime(1996, 3, 27), CreatedAt = new DateTime(2025, 5, 1) },
            new Customer { CustomerId = 11, FirstName = "William", LastName = "Taylor", Email = "william.taylor@email.com", Phone = "012-333-999", Address = "8 Bridge Street", City = "Kratie", LicenseNumber = "DL-009753", LicenseExpiry = new DateTime(2027, 4, 4), DateOfBirth = new DateTime(1987, 6, 16), CreatedAt = new DateTime(2025, 5, 9) },
            new Customer { CustomerId = 12, FirstName = "Mia", LastName = "Garcia", Email = "mia.garcia@email.com", Phone = "013-111-000", Address = "19 Highland Rd", City = "Banlung", LicenseNumber = "DL-005791", LicenseExpiry = new DateTime(2029, 10, 10), DateOfBirth = new DateTime(1993, 10, 21), CreatedAt = new DateTime(2025, 5, 16) },
            new Customer { CustomerId = 13, FirstName = "Lucas", LastName = "Hernandez", Email = "lucas.h@email.com", Phone = "013-222-111", Address = "2 Checkpoint Rd", City = "Poipet", LicenseNumber = "DL-003159", LicenseExpiry = new DateTime(2028, 1, 29), DateOfBirth = new DateTime(1990, 8, 8), CreatedAt = new DateTime(2025, 6, 1) },
            new Customer { CustomerId = 14, FirstName = "Ava", LastName = "Lopez", Email = "ava.lopez@email.com", Phone = "013-333-222", Address = "41 South Road", City = "Takeo", LicenseNumber = "DL-007531", LicenseExpiry = new DateTime(2027, 9, 15), DateOfBirth = new DateTime(1998, 12, 1), CreatedAt = new DateTime(2025, 6, 8) },
            new Customer { CustomerId = 15, FirstName = "Noah", LastName = "Clark", Email = "noah.clark@email.com", Phone = "014-111-333", Address = "10 Coast Street", City = "Koh Kong", LicenseNumber = "DL-002480", LicenseExpiry = new DateTime(2029, 5, 5), DateOfBirth = new DateTime(1986, 1, 17), CreatedAt = new DateTime(2025, 6, 15) });
    }

    private static void SeedCars(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().HasData(
            new Car { CarId = 1, CategoryId = 1, BranchId = 1, Make = "Toyota", Model = "Vios", Year = 2023, Color = "White", LicensePlate = "PP-1234", VIN = "TOYVIO2023001", DailyRate = 28m, Status = "Available", Mileage = 15200, Seats = 5, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 2, CategoryId = 2, BranchId = 1, Make = "Honda", Model = "CR-V", Year = 2024, Color = "Black", LicensePlate = "PP-5678", VIN = "HONCRV2024001", DailyRate = 60m, Status = "Rented", Mileage = 8200, Seats = 5, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 3, CategoryId = 3, BranchId = 2, Make = "BMW", Model = "520i", Year = 2024, Color = "Silver", LicensePlate = "SR-9012", VIN = "BMW5202024001", DailyRate = 130m, Status = "Available", Mileage = 4100, Seats = 5, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 4, CategoryId = 5, BranchId = 1, Make = "Toyota", Model = "Camry", Year = 2023, Color = "Gray", LicensePlate = "PP-2345", VIN = "TOYCAM2023002", DailyRate = 40m, Status = "Available", Mileage = 22100, Seats = 5, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 5, CategoryId = 6, BranchId = 6, Make = "Mazda", Model = "2", Year = 2022, Color = "Red", LicensePlate = "PP-3456", VIN = "MAZ22022001", DailyRate = 30m, Status = "Available", Mileage = 30500, Seats = 5, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 6, CategoryId = 8, BranchId = 3, Make = "Ford", Model = "Ranger", Year = 2024, Color = "Blue", LicensePlate = "SHV-1122", VIN = "FORRAN2024001", DailyRate = 55m, Status = "Available", Mileage = 9600, Seats = 5, Transmission = "Automatic", FuelType = "Diesel", CreatedAt = SeedDate },
            new Car { CarId = 7, CategoryId = 9, BranchId = 2, Make = "Toyota", Model = "HiAce", Year = 2023, Color = "White", LicensePlate = "SR-3344", VIN = "TOYHIA2023001", DailyRate = 75m, Status = "Available", Mileage = 18400, Seats = 12, Transmission = "Manual", FuelType = "Diesel", CreatedAt = SeedDate },
            new Car { CarId = 8, CategoryId = 11, BranchId = 7, Make = "BYD", Model = "Atto 3", Year = 2024, Color = "Green", LicensePlate = "PP-7788", VIN = "BYDATT2024001", DailyRate = 68m, Status = "Available", Mileage = 5300, Seats = 5, Transmission = "Automatic", FuelType = "Electric", CreatedAt = SeedDate },
            new Car { CarId = 9, CategoryId = 12, BranchId = 1, Make = "Toyota", Model = "Corolla Hybrid", Year = 2024, Color = "White", LicensePlate = "PP-8899", VIN = "TOYCOR2024001", DailyRate = 48m, Status = "Maintenance", Mileage = 11200, Seats = 5, Transmission = "Automatic", FuelType = "Hybrid", CreatedAt = SeedDate },
            new Car { CarId = 10, CategoryId = 13, BranchId = 7, Make = "Ford", Model = "Mustang", Year = 2023, Color = "Yellow", LicensePlate = "PP-9900", VIN = "FORMUS2023001", DailyRate = 160m, Status = "Available", Mileage = 7800, Seats = 4, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 11, CategoryId = 14, BranchId = 2, Make = "Lexus", Model = "RX350", Year = 2024, Color = "Black", LicensePlate = "SR-5566", VIN = "LEXRX2024001", DailyRate = 115m, Status = "Available", Mileage = 6200, Seats = 5, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 12, CategoryId = 15, BranchId = 6, Make = "Mercedes", Model = "E200", Year = 2023, Color = "Silver", LicensePlate = "PP-6677", VIN = "MERE2002023001", DailyRate = 90m, Status = "Available", Mileage = 14100, Seats = 5, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 13, CategoryId = 4, BranchId = 4, Make = "Suzuki", Model = "Swift", Year = 2022, Color = "Orange", LicensePlate = "BTB-1212", VIN = "SUZSWI2022001", DailyRate = 24m, Status = "Available", Mileage = 26800, Seats = 5, Transmission = "Manual", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 14, CategoryId = 10, BranchId = 5, Make = "Toyota", Model = "Avanza", Year = 2023, Color = "Gray", LicensePlate = "KPT-3434", VIN = "TOYAVA2023001", DailyRate = 62m, Status = "Rented", Mileage = 17500, Seats = 7, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate },
            new Car { CarId = 15, CategoryId = 7, BranchId = 8, Make = "Mazda", Model = "MX-5", Year = 2024, Color = "Red", LicensePlate = "KEP-5656", VIN = "MAZMX52024001", DailyRate = 98m, Status = "Available", Mileage = 3500, Seats = 2, Transmission = "Automatic", FuelType = "Gasoline", CreatedAt = SeedDate });
    }

    private static void SeedContracts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RentalContract>().HasData(
            new RentalContract { ContractId = 1, CustomerId = 1, EmployeeId = 2, BranchId = 1, ContractNumber = "RC-2025-0001", StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 6, 5), Status = "Completed", TotalAmount = 140m, DepositAmount = 50m, Notes = "City trip", CreatedAt = new DateTime(2025, 5, 28) },
            new RentalContract { ContractId = 2, CustomerId = 2, EmployeeId = 3, BranchId = 2, ContractNumber = "RC-2025-0002", StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 6, 14), Status = "Completed", TotalAmount = 520m, DepositAmount = 100m, Notes = "Temple tour", CreatedAt = new DateTime(2025, 6, 8) },
            new RentalContract { ContractId = 3, CustomerId = 3, EmployeeId = 2, BranchId = 1, ContractNumber = "RC-2025-0003", StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 7, 7), Status = "Active", TotalAmount = 360m, DepositAmount = 80m, Notes = "Business week", CreatedAt = new DateTime(2025, 6, 28) },
            new RentalContract { ContractId = 4, CustomerId = 4, EmployeeId = 5, BranchId = 3, ContractNumber = "RC-2025-0004", StartDate = new DateTime(2025, 7, 5), EndDate = new DateTime(2025, 7, 8), Status = "Active", TotalAmount = 165m, DepositAmount = 60m, Notes = "Beach weekend", CreatedAt = new DateTime(2025, 7, 2) },
            new RentalContract { ContractId = 5, CustomerId = 5, EmployeeId = 7, BranchId = 4, ContractNumber = "RC-2025-0005", StartDate = new DateTime(2025, 5, 1), EndDate = new DateTime(2025, 5, 4), Status = "Completed", TotalAmount = 96m, DepositAmount = 40m, Notes = null, CreatedAt = new DateTime(2025, 4, 28) },
            new RentalContract { ContractId = 6, CustomerId = 6, EmployeeId = 8, BranchId = 5, ContractNumber = "RC-2025-0006", StartDate = new DateTime(2025, 7, 10), EndDate = new DateTime(2025, 7, 15), Status = "Active", TotalAmount = 310m, DepositAmount = 70m, Notes = "Family trip", CreatedAt = new DateTime(2025, 7, 7) },
            new RentalContract { ContractId = 7, CustomerId = 7, EmployeeId = 9, BranchId = 6, ContractNumber = "RC-2025-0007", StartDate = new DateTime(2025, 4, 12), EndDate = new DateTime(2025, 4, 15), Status = "Completed", TotalAmount = 120m, DepositAmount = 50m, Notes = null, CreatedAt = new DateTime(2025, 4, 10) },
            new RentalContract { ContractId = 8, CustomerId = 8, EmployeeId = 4, BranchId = 2, ContractNumber = "RC-2025-0008", StartDate = new DateTime(2025, 6, 20), EndDate = new DateTime(2025, 6, 25), Status = "Completed", TotalAmount = 375m, DepositAmount = 90m, Notes = "Group van", CreatedAt = new DateTime(2025, 6, 18) },
            new RentalContract { ContractId = 9, CustomerId = 9, EmployeeId = 10, BranchId = 7, ContractNumber = "RC-2025-0009", StartDate = new DateTime(2025, 7, 12), EndDate = new DateTime(2025, 7, 14), Status = "Active", TotalAmount = 136m, DepositAmount = 50m, Notes = "Airport pickup", CreatedAt = new DateTime(2025, 7, 11) },
            new RentalContract { ContractId = 10, CustomerId = 10, EmployeeId = 11, BranchId = 8, ContractNumber = "RC-2025-0010", StartDate = new DateTime(2025, 5, 20), EndDate = new DateTime(2025, 5, 22), Status = "Completed", TotalAmount = 196m, DepositAmount = 80m, Notes = "Convertible weekend", CreatedAt = new DateTime(2025, 5, 18) },
            new RentalContract { ContractId = 11, CustomerId = 11, EmployeeId = 12, BranchId = 9, ContractNumber = "RC-2025-0011", StartDate = new DateTime(2025, 3, 5), EndDate = new DateTime(2025, 3, 8), Status = "Cancelled", TotalAmount = 0m, DepositAmount = 0m, Notes = "Customer cancelled", CreatedAt = new DateTime(2025, 3, 1) },
            new RentalContract { ContractId = 12, CustomerId = 12, EmployeeId = 13, BranchId = 10, ContractNumber = "RC-2025-0012", StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 6, 3), Status = "Completed", TotalAmount = 180m, DepositAmount = 60m, Notes = null, CreatedAt = new DateTime(2025, 5, 29) },
            new RentalContract { ContractId = 13, CustomerId = 13, EmployeeId = 2, BranchId = 1, ContractNumber = "RC-2025-0013", StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 7, 10), Status = "Active", TotalAmount = 900m, DepositAmount = 150m, Notes = "Long rental", CreatedAt = new DateTime(2025, 6, 27) },
            new RentalContract { ContractId = 14, CustomerId = 14, EmployeeId = 1, BranchId = 1, ContractNumber = "RC-2025-0014", StartDate = new DateTime(2025, 5, 8), EndDate = new DateTime(2025, 5, 10), Status = "Completed", TotalAmount = 80m, DepositAmount = 30m, Notes = null, CreatedAt = new DateTime(2025, 5, 6) },
            new RentalContract { ContractId = 15, CustomerId = 15, EmployeeId = 15, BranchId = 7, ContractNumber = "RC-2025-0015", StartDate = new DateTime(2025, 7, 8), EndDate = new DateTime(2025, 7, 12), Status = "Active", TotalAmount = 640m, DepositAmount = 120m, Notes = "Sports car", CreatedAt = new DateTime(2025, 7, 6) });
    }

    private static void SeedContractDetails(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RentalContractDetail>().HasData(
            new RentalContractDetail { DetailId = 1, ContractId = 1, CarId = 1, DailyRate = 28m, Days = 5, SubTotal = 140m, Notes = null },
            new RentalContractDetail { DetailId = 2, ContractId = 2, CarId = 3, DailyRate = 130m, Days = 4, SubTotal = 520m, Notes = null },
            new RentalContractDetail { DetailId = 3, ContractId = 3, CarId = 2, DailyRate = 60m, Days = 6, SubTotal = 360m, Notes = null },
            new RentalContractDetail { DetailId = 4, ContractId = 4, CarId = 6, DailyRate = 55m, Days = 3, SubTotal = 165m, Notes = null },
            new RentalContractDetail { DetailId = 5, ContractId = 5, CarId = 13, DailyRate = 24m, Days = 4, SubTotal = 96m, Notes = null },
            new RentalContractDetail { DetailId = 6, ContractId = 6, CarId = 14, DailyRate = 62m, Days = 5, SubTotal = 310m, Notes = null },
            new RentalContractDetail { DetailId = 7, ContractId = 7, CarId = 5, DailyRate = 30m, Days = 4, SubTotal = 120m, Notes = null },
            new RentalContractDetail { DetailId = 8, ContractId = 8, CarId = 7, DailyRate = 75m, Days = 5, SubTotal = 375m, Notes = null },
            new RentalContractDetail { DetailId = 9, ContractId = 9, CarId = 8, DailyRate = 68m, Days = 2, SubTotal = 136m, Notes = null },
            new RentalContractDetail { DetailId = 10, ContractId = 10, CarId = 15, DailyRate = 98m, Days = 2, SubTotal = 196m, Notes = null },
            new RentalContractDetail { DetailId = 11, ContractId = 12, CarId = 11, DailyRate = 90m, Days = 2, SubTotal = 180m, Notes = "Adjusted rate" },
            new RentalContractDetail { DetailId = 12, ContractId = 13, CarId = 12, DailyRate = 90m, Days = 10, SubTotal = 900m, Notes = null },
            new RentalContractDetail { DetailId = 13, ContractId = 14, CarId = 4, DailyRate = 40m, Days = 2, SubTotal = 80m, Notes = null },
            new RentalContractDetail { DetailId = 14, ContractId = 15, CarId = 10, DailyRate = 160m, Days = 4, SubTotal = 640m, Notes = null },
            new RentalContractDetail { DetailId = 15, ContractId = 1, CarId = 5, DailyRate = 30m, Days = 2, SubTotal = 60m, Notes = "Extra day hatchback" });
    }

    private static void SeedPayments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>().HasData(
            new Payment { PaymentId = 1, ContractId = 1, Amount = 50m, PaymentDate = new DateTime(2025, 5, 28, 10, 0, 0), PaymentMethod = "Cash", TransactionReference = "CASH-001", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 2 },
            new Payment { PaymentId = 2, ContractId = 1, Amount = 140m, PaymentDate = new DateTime(2025, 6, 5, 16, 0, 0), PaymentMethod = "Card", TransactionReference = "CARD-1001", Status = "Completed", Notes = "Final payment", ReceivedByEmployeeId = 2 },
            new Payment { PaymentId = 3, ContractId = 2, Amount = 100m, PaymentDate = new DateTime(2025, 6, 8, 9, 30, 0), PaymentMethod = "Cash", TransactionReference = "CASH-002", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 3 },
            new Payment { PaymentId = 4, ContractId = 2, Amount = 520m, PaymentDate = new DateTime(2025, 6, 14, 15, 0, 0), PaymentMethod = "Transfer", TransactionReference = "TRF-2002", Status = "Completed", Notes = null, ReceivedByEmployeeId = 4 },
            new Payment { PaymentId = 5, ContractId = 3, Amount = 80m, PaymentDate = new DateTime(2025, 6, 28, 11, 0, 0), PaymentMethod = "Card", TransactionReference = "CARD-1003", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 2 },
            new Payment { PaymentId = 6, ContractId = 4, Amount = 60m, PaymentDate = new DateTime(2025, 7, 2, 14, 0, 0), PaymentMethod = "Cash", TransactionReference = "CASH-004", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 5 },
            new Payment { PaymentId = 7, ContractId = 5, Amount = 136m, PaymentDate = new DateTime(2025, 5, 4, 17, 0, 0), PaymentMethod = "Cash", TransactionReference = "CASH-005", Status = "Completed", Notes = "Full payment", ReceivedByEmployeeId = 7 },
            new Payment { PaymentId = 8, ContractId = 6, Amount = 70m, PaymentDate = new DateTime(2025, 7, 7, 10, 0, 0), PaymentMethod = "Card", TransactionReference = "CARD-1006", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 8 },
            new Payment { PaymentId = 9, ContractId = 7, Amount = 170m, PaymentDate = new DateTime(2025, 4, 15, 12, 0, 0), PaymentMethod = "Transfer", TransactionReference = "TRF-2007", Status = "Completed", Notes = null, ReceivedByEmployeeId = 9 },
            new Payment { PaymentId = 10, ContractId = 8, Amount = 465m, PaymentDate = new DateTime(2025, 6, 25, 18, 0, 0), PaymentMethod = "Card", TransactionReference = "CARD-1008", Status = "Completed", Notes = "Deposit + balance", ReceivedByEmployeeId = 4 },
            new Payment { PaymentId = 11, ContractId = 9, Amount = 50m, PaymentDate = new DateTime(2025, 7, 11, 8, 0, 0), PaymentMethod = "Cash", TransactionReference = "CASH-009", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 10 },
            new Payment { PaymentId = 12, ContractId = 10, Amount = 276m, PaymentDate = new DateTime(2025, 5, 22, 19, 0, 0), PaymentMethod = "Card", TransactionReference = "CARD-1010", Status = "Completed", Notes = null, ReceivedByEmployeeId = 11 },
            new Payment { PaymentId = 13, ContractId = 12, Amount = 240m, PaymentDate = new DateTime(2025, 6, 3, 13, 0, 0), PaymentMethod = "Cash", TransactionReference = "CASH-012", Status = "Completed", Notes = null, ReceivedByEmployeeId = 13 },
            new Payment { PaymentId = 14, ContractId = 13, Amount = 150m, PaymentDate = new DateTime(2025, 6, 27, 9, 0, 0), PaymentMethod = "Transfer", TransactionReference = "TRF-2013", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 2 },
            new Payment { PaymentId = 15, ContractId = 15, Amount = 120m, PaymentDate = new DateTime(2025, 7, 6, 16, 0, 0), PaymentMethod = "Card", TransactionReference = "CARD-1015", Status = "Completed", Notes = "Deposit", ReceivedByEmployeeId = 15 });
    }

    private static void SeedReturns(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarReturn>().HasData(
            new CarReturn { ReturnId = 1, ContractId = 1, CarId = 1, EmployeeId = 2, ReturnDate = new DateTime(2025, 6, 5, 15, 30, 0), OdometerReading = 15680, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = "Good condition", Status = "Completed" },
            new CarReturn { ReturnId = 2, ContractId = 2, CarId = 3, EmployeeId = 3, ReturnDate = new DateTime(2025, 6, 14, 14, 0, 0), OdometerReading = 4650, FuelLevel = "3/4", LateFee = 0m, DamageFee = 25m, Notes = "Minor scratch", Status = "Completed" },
            new CarReturn { ReturnId = 3, ContractId = 5, CarId = 13, EmployeeId = 7, ReturnDate = new DateTime(2025, 5, 4, 16, 20, 0), OdometerReading = 27100, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = null, Status = "Completed" },
            new CarReturn { ReturnId = 4, ContractId = 7, CarId = 5, EmployeeId = 9, ReturnDate = new DateTime(2025, 4, 15, 11, 45, 0), OdometerReading = 30950, FuelLevel = "Half", LateFee = 15m, DamageFee = 0m, Notes = "1 hour late", Status = "Completed" },
            new CarReturn { ReturnId = 5, ContractId = 8, CarId = 7, EmployeeId = 4, ReturnDate = new DateTime(2025, 6, 25, 17, 10, 0), OdometerReading = 19100, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = null, Status = "Completed" },
            new CarReturn { ReturnId = 6, ContractId = 10, CarId = 15, EmployeeId = 11, ReturnDate = new DateTime(2025, 5, 22, 18, 30, 0), OdometerReading = 3720, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = "Excellent", Status = "Completed" },
            new CarReturn { ReturnId = 7, ContractId = 12, CarId = 11, EmployeeId = 13, ReturnDate = new DateTime(2025, 6, 3, 12, 0, 0), OdometerReading = 6480, FuelLevel = "3/4", LateFee = 0m, DamageFee = 40m, Notes = "Bumper mark", Status = "Completed" },
            new CarReturn { ReturnId = 8, ContractId = 14, CarId = 4, EmployeeId = 1, ReturnDate = new DateTime(2025, 5, 10, 10, 15, 0), OdometerReading = 22340, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = null, Status = "Completed" },
            new CarReturn { ReturnId = 9, ContractId = 1, CarId = 5, EmployeeId = 14, ReturnDate = new DateTime(2025, 6, 5, 16, 0, 0), OdometerReading = 30700, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = "Extra car return", Status = "Completed" },
            new CarReturn { ReturnId = 10, ContractId = 2, CarId = 1, EmployeeId = 14, ReturnDate = new DateTime(2025, 6, 14, 15, 0, 0), OdometerReading = 15720, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = "Inspection follow-up", Status = "Completed" },
            new CarReturn { ReturnId = 11, ContractId = 5, CarId = 1, EmployeeId = 2, ReturnDate = new DateTime(2025, 5, 4, 17, 0, 0), OdometerReading = 15750, FuelLevel = "Full", LateFee = 0m, DamageFee = 10m, Notes = "Cleaning fee", Status = "Completed" },
            new CarReturn { ReturnId = 12, ContractId = 7, CarId = 4, EmployeeId = 9, ReturnDate = new DateTime(2025, 4, 15, 13, 0, 0), OdometerReading = 22400, FuelLevel = "3/4", LateFee = 0m, DamageFee = 0m, Notes = null, Status = "Completed" },
            new CarReturn { ReturnId = 13, ContractId = 8, CarId = 3, EmployeeId = 3, ReturnDate = new DateTime(2025, 6, 25, 18, 0, 0), OdometerReading = 4700, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = null, Status = "Completed" },
            new CarReturn { ReturnId = 14, ContractId = 10, CarId = 8, EmployeeId = 10, ReturnDate = new DateTime(2025, 5, 22, 19, 30, 0), OdometerReading = 5450, FuelLevel = "Full", LateFee = 0m, DamageFee = 0m, Notes = null, Status = "Completed" },
            new CarReturn { ReturnId = 15, ContractId = 12, CarId = 13, EmployeeId = 7, ReturnDate = new DateTime(2025, 6, 3, 14, 0, 0), OdometerReading = 27220, FuelLevel = "Half", LateFee = 15m, DamageFee = 0m, Notes = "Late return", Status = "Completed" });
    }

    private static void SeedInspections(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReturnInspection>().HasData(
            new ReturnInspection { InspectionId = 1, ReturnId = 1, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 6, 5, 15, 45, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 2, ReturnId = 2, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 6, 14, 14, 20, 0), ExteriorCondition = "Fair", InteriorCondition = "Good", HasDamage = true, DamageDescription = "Left door scratch", EstimatedRepairCost = 25m, Notes = "Charged to customer" },
            new ReturnInspection { InspectionId = 3, ReturnId = 3, InspectedByEmployeeId = 8, InspectionDate = new DateTime(2025, 5, 4, 16, 40, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 4, ReturnId = 4, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 4, 15, 12, 0, 0), ExteriorCondition = "Good", InteriorCondition = "Fair", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = "Needs interior clean" },
            new ReturnInspection { InspectionId = 5, ReturnId = 5, InspectedByEmployeeId = 8, InspectionDate = new DateTime(2025, 6, 25, 17, 30, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 6, ReturnId = 6, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 5, 22, 18, 45, 0), ExteriorCondition = "Excellent", InteriorCondition = "Excellent", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 7, ReturnId = 7, InspectedByEmployeeId = 8, InspectionDate = new DateTime(2025, 6, 3, 12, 20, 0), ExteriorCondition = "Fair", InteriorCondition = "Good", HasDamage = true, DamageDescription = "Rear bumper mark", EstimatedRepairCost = 40m, Notes = null },
            new ReturnInspection { InspectionId = 8, ReturnId = 8, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 5, 10, 10, 30, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 9, ReturnId = 9, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 6, 5, 16, 15, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 10, ReturnId = 10, InspectedByEmployeeId = 8, InspectionDate = new DateTime(2025, 6, 14, 15, 20, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 11, ReturnId = 11, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 5, 4, 17, 15, 0), ExteriorCondition = "Good", InteriorCondition = "Fair", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 10m, Notes = "Cleaning only" },
            new ReturnInspection { InspectionId = 12, ReturnId = 12, InspectedByEmployeeId = 8, InspectionDate = new DateTime(2025, 4, 15, 13, 20, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 13, ReturnId = 13, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 6, 25, 18, 20, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 14, ReturnId = 14, InspectedByEmployeeId = 8, InspectionDate = new DateTime(2025, 5, 22, 19, 45, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = null },
            new ReturnInspection { InspectionId = 15, ReturnId = 15, InspectedByEmployeeId = 14, InspectionDate = new DateTime(2025, 6, 3, 14, 20, 0), ExteriorCondition = "Good", InteriorCondition = "Good", HasDamage = false, DamageDescription = null, EstimatedRepairCost = 0m, Notes = "Late but ok" });
    }

    private static void SeedMaintenance(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarMaintenance>().HasData(
            new CarMaintenance { MaintenanceId = 1, CarId = 9, EmployeeId = 8, MaintenanceType = "Oil Change", Description = "Hybrid system oil service", StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 7, 2), Cost = 80m, Status = "InProgress", ServiceProvider = "Toyota Service", Notes = null },
            new CarMaintenance { MaintenanceId = 2, CarId = 1, EmployeeId = 8, MaintenanceType = "Tire Rotation", Description = "Rotate and balance tires", StartDate = new DateTime(2025, 3, 10), EndDate = new DateTime(2025, 3, 10), Cost = 35m, Status = "Completed", ServiceProvider = "Local Garage", Notes = null },
            new CarMaintenance { MaintenanceId = 3, CarId = 2, EmployeeId = 8, MaintenanceType = "Brake Check", Description = "Inspect brake pads", StartDate = new DateTime(2025, 4, 5), EndDate = new DateTime(2025, 4, 5), Cost = 50m, Status = "Completed", ServiceProvider = "Honda Care", Notes = null },
            new CarMaintenance { MaintenanceId = 4, CarId = 3, EmployeeId = 14, MaintenanceType = "AC Service", Description = "AC gas refill", StartDate = new DateTime(2025, 5, 12), EndDate = new DateTime(2025, 5, 12), Cost = 70m, Status = "Completed", ServiceProvider = "BMW Center", Notes = null },
            new CarMaintenance { MaintenanceId = 5, CarId = 4, EmployeeId = 8, MaintenanceType = "Battery", Description = "Replace battery", StartDate = new DateTime(2025, 2, 20), EndDate = new DateTime(2025, 2, 20), Cost = 120m, Status = "Completed", ServiceProvider = "Toyota Service", Notes = null },
            new CarMaintenance { MaintenanceId = 6, CarId = 6, EmployeeId = 8, MaintenanceType = "Engine Tune", Description = "Diesel injector cleaning", StartDate = new DateTime(2025, 6, 1), EndDate = new DateTime(2025, 6, 2), Cost = 150m, Status = "Completed", ServiceProvider = "Ford Workshop", Notes = null },
            new CarMaintenance { MaintenanceId = 7, CarId = 7, EmployeeId = 14, MaintenanceType = "Transmission", Description = "Gearbox fluid change", StartDate = new DateTime(2025, 6, 15), EndDate = new DateTime(2025, 6, 16), Cost = 200m, Status = "Completed", ServiceProvider = "Toyota Service", Notes = null },
            new CarMaintenance { MaintenanceId = 8, CarId = 8, EmployeeId = 8, MaintenanceType = "Software Update", Description = "EV firmware update", StartDate = new DateTime(2025, 7, 5), EndDate = null, Cost = 0m, Status = "Scheduled", ServiceProvider = "BYD Service", Notes = "Next week" },
            new CarMaintenance { MaintenanceId = 9, CarId = 10, EmployeeId = 8, MaintenanceType = "Detailing", Description = "Full exterior polish", StartDate = new DateTime(2025, 5, 1), EndDate = new DateTime(2025, 5, 1), Cost = 90m, Status = "Completed", ServiceProvider = "Premium Detail", Notes = null },
            new CarMaintenance { MaintenanceId = 10, CarId = 11, EmployeeId = 14, MaintenanceType = "Oil Change", Description = "Premium oil service", StartDate = new DateTime(2025, 4, 18), EndDate = new DateTime(2025, 4, 18), Cost = 110m, Status = "Completed", ServiceProvider = "Lexus Care", Notes = null },
            new CarMaintenance { MaintenanceId = 11, CarId = 12, EmployeeId = 8, MaintenanceType = "Inspection", Description = "Annual safety inspection", StartDate = new DateTime(2025, 3, 22), EndDate = new DateTime(2025, 3, 22), Cost = 45m, Status = "Completed", ServiceProvider = "Mercedes Center", Notes = null },
            new CarMaintenance { MaintenanceId = 12, CarId = 13, EmployeeId = 8, MaintenanceType = "Clutch", Description = "Clutch adjustment", StartDate = new DateTime(2025, 6, 20), EndDate = new DateTime(2025, 6, 21), Cost = 180m, Status = "Completed", ServiceProvider = "Suzuki Shop", Notes = null },
            new CarMaintenance { MaintenanceId = 13, CarId = 14, EmployeeId = 14, MaintenanceType = "Coolant", Description = "Coolant flush", StartDate = new DateTime(2025, 5, 28), EndDate = new DateTime(2025, 5, 28), Cost = 40m, Status = "Completed", ServiceProvider = "Local Garage", Notes = null },
            new CarMaintenance { MaintenanceId = 14, CarId = 15, EmployeeId = 8, MaintenanceType = "Alignment", Description = "Wheel alignment", StartDate = new DateTime(2025, 7, 8), EndDate = null, Cost = 55m, Status = "Scheduled", ServiceProvider = "Mazda Service", Notes = null },
            new CarMaintenance { MaintenanceId = 15, CarId = 5, EmployeeId = 8, MaintenanceType = "Oil Change", Description = "Regular oil change", StartDate = new DateTime(2025, 7, 9), EndDate = null, Cost = 45m, Status = "Scheduled", ServiceProvider = "Mazda Service", Notes = null });
    }

    private static void SeedStatusHistory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarStatusHistory>().HasData(
            new CarStatusHistory { HistoryId = 1, CarId = 1, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 6, 1, 9, 0, 0), ChangedByEmployeeId = 2, Reason = "Contract RC-2025-0001", Notes = null },
            new CarStatusHistory { HistoryId = 2, CarId = 1, PreviousStatus = "Rented", NewStatus = "Available", ChangedAt = new DateTime(2025, 6, 5, 15, 40, 0), ChangedByEmployeeId = 2, Reason = "Returned", Notes = null },
            new CarStatusHistory { HistoryId = 3, CarId = 2, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 7, 1, 8, 30, 0), ChangedByEmployeeId = 2, Reason = "Contract RC-2025-0003", Notes = null },
            new CarStatusHistory { HistoryId = 4, CarId = 3, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 6, 10, 10, 0, 0), ChangedByEmployeeId = 3, Reason = "Contract RC-2025-0002", Notes = null },
            new CarStatusHistory { HistoryId = 5, CarId = 3, PreviousStatus = "Rented", NewStatus = "Available", ChangedAt = new DateTime(2025, 6, 14, 14, 10, 0), ChangedByEmployeeId = 3, Reason = "Returned", Notes = null },
            new CarStatusHistory { HistoryId = 6, CarId = 9, PreviousStatus = "Available", NewStatus = "Maintenance", ChangedAt = new DateTime(2025, 7, 1, 7, 0, 0), ChangedByEmployeeId = 8, Reason = "Oil change", Notes = null },
            new CarStatusHistory { HistoryId = 7, CarId = 14, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 7, 10, 9, 0, 0), ChangedByEmployeeId = 8, Reason = "Contract RC-2025-0006", Notes = null },
            new CarStatusHistory { HistoryId = 8, CarId = 6, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 7, 5, 11, 0, 0), ChangedByEmployeeId = 5, Reason = "Contract RC-2025-0004", Notes = null },
            new CarStatusHistory { HistoryId = 9, CarId = 8, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 7, 12, 8, 0, 0), ChangedByEmployeeId = 10, Reason = "Contract RC-2025-0009", Notes = null },
            new CarStatusHistory { HistoryId = 10, CarId = 10, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 7, 8, 15, 0, 0), ChangedByEmployeeId = 15, Reason = "Contract RC-2025-0015", Notes = null },
            new CarStatusHistory { HistoryId = 11, CarId = 5, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 4, 12, 9, 0, 0), ChangedByEmployeeId = 9, Reason = "Contract RC-2025-0007", Notes = null },
            new CarStatusHistory { HistoryId = 12, CarId = 5, PreviousStatus = "Rented", NewStatus = "Available", ChangedAt = new DateTime(2025, 4, 15, 12, 0, 0), ChangedByEmployeeId = 9, Reason = "Returned", Notes = null },
            new CarStatusHistory { HistoryId = 13, CarId = 7, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 6, 20, 10, 0, 0), ChangedByEmployeeId = 4, Reason = "Contract RC-2025-0008", Notes = null },
            new CarStatusHistory { HistoryId = 14, CarId = 7, PreviousStatus = "Rented", NewStatus = "Available", ChangedAt = new DateTime(2025, 6, 25, 17, 20, 0), ChangedByEmployeeId = 4, Reason = "Returned", Notes = null },
            new CarStatusHistory { HistoryId = 15, CarId = 15, PreviousStatus = "Available", NewStatus = "Rented", ChangedAt = new DateTime(2025, 5, 20, 9, 30, 0), ChangedByEmployeeId = 11, Reason = "Contract RC-2025-0010", Notes = null });
    }

    private static void SeedSettings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Setting>().HasData(
            new Setting { SettingId = 1, SettingKey = "CompanyName", SettingValue = "Car Rental Management System", GroupName = "Company", Description = "Company display name", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 2, SettingKey = "CompanyPhone", SettingValue = "023-111-222", GroupName = "Company", Description = "Main contact phone", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 3, SettingKey = "CompanyEmail", SettingValue = "info@carrental.local", GroupName = "Company", Description = "Main contact email", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 4, SettingKey = "Currency", SettingValue = "USD", GroupName = "Finance", Description = "Default currency code", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 5, SettingKey = "TaxRate", SettingValue = "10", GroupName = "Finance", Description = "Default tax percentage", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 6, SettingKey = "LateFeePerDay", SettingValue = "15", GroupName = "Rental", Description = "Late return fee per day", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 7, SettingKey = "CompanyAddress", SettingValue = "123 Norodom Blvd, Phnom Penh", GroupName = "Company", Description = "Head office address", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 8, SettingKey = "DepositDefault", SettingValue = "50", GroupName = "Rental", Description = "Default deposit amount", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 9, SettingKey = "MinRentalDays", SettingValue = "1", GroupName = "Rental", Description = "Minimum rental days", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 10, SettingKey = "MaxRentalDays", SettingValue = "30", GroupName = "Rental", Description = "Maximum rental days", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 11, SettingKey = "InvoicePrefix", SettingValue = "INV-", GroupName = "Finance", Description = "Invoice number prefix", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 12, SettingKey = "ContractPrefix", SettingValue = "RC-", GroupName = "Rental", Description = "Contract number prefix", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 13, SettingKey = "SupportHours", SettingValue = "08:00-20:00", GroupName = "Company", Description = "Customer support hours", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 14, SettingKey = "FuelPolicy", SettingValue = "Full-to-Full", GroupName = "Rental", Description = "Fuel return policy", IsActive = true, UpdatedAt = SeedDate },
            new Setting { SettingId = 15, SettingKey = "DamageFeeMin", SettingValue = "25", GroupName = "Finance", Description = "Minimum damage fee", IsActive = true, UpdatedAt = SeedDate });
    }
}
