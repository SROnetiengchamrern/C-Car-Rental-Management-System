using CarRentalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CarCategory> CarCategories => Set<CarCategory>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<RentalContract> RentalContracts => Set<RentalContract>();
    public DbSet<RentalContractDetail> RentalContractDetails => Set<RentalContractDetail>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<CarReturn> CarReturns => Set<CarReturn>();
    public DbSet<ReturnInspection> ReturnInspections => Set<ReturnInspection>();
    public DbSet<CarMaintenance> CarMaintenances => Set<CarMaintenance>();
    public DbSet<CarStatusHistory> CarStatusHistories => Set<CarStatusHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CarCategory>().ToTable("CarCategories");
        modelBuilder.Entity<Car>().ToTable("Cars");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Branch>().ToTable("Branches");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<RentalContract>().ToTable("RentalContracts");
        modelBuilder.Entity<RentalContractDetail>().ToTable("RentalContractDetails");
        modelBuilder.Entity<Payment>().ToTable("Payments");
        modelBuilder.Entity<CarReturn>().ToTable("CarReturns");
        modelBuilder.Entity<ReturnInspection>().ToTable("ReturnInspections");
        modelBuilder.Entity<CarMaintenance>().ToTable("CarMaintenance");
        modelBuilder.Entity<CarStatusHistory>().ToTable("CarStatusHistory");

        modelBuilder.Entity<Car>()
            .HasIndex(c => c.LicensePlate)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.LicenseNumber)
            .IsUnique();

        modelBuilder.Entity<RentalContract>()
            .HasIndex(c => c.ContractNumber)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Branch)
            .WithMany(b => b.Employees)
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Car>()
            .HasOne(c => c.Category)
            .WithMany(cat => cat.Cars)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Car>()
            .HasOne(c => c.Branch)
            .WithMany(b => b.Cars)
            .HasForeignKey(c => c.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RentalContract>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.RentalContracts)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RentalContract>()
            .HasOne(r => r.Employee)
            .WithMany(e => e.RentalContracts)
            .HasForeignKey(r => r.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RentalContract>()
            .HasOne(r => r.Branch)
            .WithMany(b => b.RentalContracts)
            .HasForeignKey(r => r.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RentalContractDetail>()
            .HasOne(d => d.RentalContract)
            .WithMany(c => c.RentalContractDetails)
            .HasForeignKey(d => d.ContractId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RentalContractDetail>()
            .HasOne(d => d.Car)
            .WithMany(c => c.RentalContractDetails)
            .HasForeignKey(d => d.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.RentalContract)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.ContractId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.ReceivedByEmployee)
            .WithMany(e => e.PaymentsReceived)
            .HasForeignKey(p => p.ReceivedByEmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<CarReturn>()
            .HasOne(r => r.RentalContract)
            .WithMany(c => c.CarReturns)
            .HasForeignKey(r => r.ContractId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CarReturn>()
            .HasOne(r => r.Car)
            .WithMany(c => c.CarReturns)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CarReturn>()
            .HasOne(r => r.Employee)
            .WithMany(e => e.CarReturns)
            .HasForeignKey(r => r.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ReturnInspection>()
            .HasOne(i => i.CarReturn)
            .WithMany(r => r.ReturnInspections)
            .HasForeignKey(i => i.ReturnId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReturnInspection>()
            .HasOne(i => i.InspectedByEmployee)
            .WithMany(e => e.ReturnInspections)
            .HasForeignKey(i => i.InspectedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CarMaintenance>()
            .HasOne(m => m.Car)
            .WithMany(c => c.CarMaintenances)
            .HasForeignKey(m => m.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CarMaintenance>()
            .HasOne(m => m.Employee)
            .WithMany(e => e.CarMaintenances)
            .HasForeignKey(m => m.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<CarStatusHistory>()
            .HasOne(h => h.Car)
            .WithMany(c => c.CarStatusHistories)
            .HasForeignKey(h => h.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CarStatusHistory>()
            .HasOne(h => h.ChangedByEmployee)
            .WithMany(e => e.CarStatusHistories)
            .HasForeignKey(h => h.ChangedByEmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>().HasData(
            new Branch
            {
                BranchId = 1,
                BranchName = "Phnom Penh Central",
                Address = "123 Norodom Blvd",
                City = "Phnom Penh",
                Phone = "023-111-222",
                Email = "pp@carrental.local",
                ManagerName = "Sokha Meas",
                IsActive = true
            },
            new Branch
            {
                BranchId = 2,
                BranchName = "Siem Reap Airport",
                Address = "Airport Road",
                City = "Siem Reap",
                Phone = "063-333-444",
                Email = "sr@carrental.local",
                ManagerName = "Vannak Chhim",
                IsActive = true
            });

        modelBuilder.Entity<CarCategory>().HasData(
            new CarCategory { CategoryId = 1, CategoryName = "Economy", Description = "Affordable compact cars", BaseDailyRate = 25m, IsActive = true },
            new CarCategory { CategoryId = 2, CategoryName = "SUV", Description = "Family and adventure SUVs", BaseDailyRate = 55m, IsActive = true },
            new CarCategory { CategoryId = 3, CategoryName = "Luxury", Description = "Premium vehicles", BaseDailyRate = 120m, IsActive = true });

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                BranchId = 1,
                FirstName = "Dara",
                LastName = "Kim",
                Email = "dara.kim@carrental.local",
                Phone = "012-345-678",
                Position = "Manager",
                HireDate = new DateTime(2023, 1, 15),
                Salary = 800m,
                IsActive = true
            },
            new Employee
            {
                EmployeeId = 2,
                BranchId = 1,
                FirstName = "Srey",
                LastName = "Nin",
                Email = "srey.nin@carrental.local",
                Phone = "012-987-654",
                Position = "Staff",
                HireDate = new DateTime(2024, 3, 1),
                Salary = 450m,
                IsActive = true
            },
            new Employee
            {
                EmployeeId = 3,
                BranchId = 2,
                FirstName = "Rith",
                LastName = "Pov",
                Email = "rith.pov@carrental.local",
                Phone = "015-222-333",
                Position = "Staff",
                HireDate = new DateTime(2024, 6, 10),
                Salary = 450m,
                IsActive = true
            });

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@email.com",
                Phone = "010-111-222",
                Address = "45 Street 51",
                City = "Phnom Penh",
                LicenseNumber = "DL-001234",
                LicenseExpiry = new DateTime(2028, 5, 20),
                DateOfBirth = new DateTime(1990, 4, 12),
                CreatedAt = new DateTime(2025, 1, 10)
            },
            new Customer
            {
                CustomerId = 2,
                FirstName = "Lisa",
                LastName = "Chan",
                Email = "lisa.chan@email.com",
                Phone = "010-333-444",
                Address = "88 Pub Street",
                City = "Siem Reap",
                LicenseNumber = "DL-005678",
                LicenseExpiry = new DateTime(2027, 11, 8),
                DateOfBirth = new DateTime(1995, 8, 3),
                CreatedAt = new DateTime(2025, 2, 5)
            });

        modelBuilder.Entity<Car>().HasData(
            new Car
            {
                CarId = 1,
                CategoryId = 1,
                BranchId = 1,
                Make = "Toyota",
                Model = "Vios",
                Year = 2023,
                Color = "White",
                LicensePlate = "PP-1234",
                VIN = "TOYVIO2023001",
                DailyRate = 28m,
                Status = "Available",
                Mileage = 15200,
                Seats = 5,
                Transmission = "Automatic",
                FuelType = "Gasoline",
                CreatedAt = new DateTime(2025, 1, 1)
            },
            new Car
            {
                CarId = 2,
                CategoryId = 2,
                BranchId = 1,
                Make = "Honda",
                Model = "CR-V",
                Year = 2024,
                Color = "Black",
                LicensePlate = "PP-5678",
                VIN = "HONCRV2024001",
                DailyRate = 60m,
                Status = "Available",
                Mileage = 8200,
                Seats = 5,
                Transmission = "Automatic",
                FuelType = "Gasoline",
                CreatedAt = new DateTime(2025, 1, 1)
            },
            new Car
            {
                CarId = 3,
                CategoryId = 3,
                BranchId = 2,
                Make = "BMW",
                Model = "520i",
                Year = 2024,
                Color = "Silver",
                LicensePlate = "SR-9012",
                VIN = "BMW5202024001",
                DailyRate = 130m,
                Status = "Available",
                Mileage = 4100,
                Seats = 5,
                Transmission = "Automatic",
                FuelType = "Gasoline",
                CreatedAt = new DateTime(2025, 1, 1)
            });
    }
}
