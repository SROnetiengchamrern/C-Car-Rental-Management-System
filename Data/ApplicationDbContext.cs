using CarRentalManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
    public DbSet<Setting> Settings => Set<Setting>();
    public DbSet<BookingRequest> BookingRequests => Set<BookingRequest>();

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
        modelBuilder.Entity<Setting>().ToTable("Settings");
        modelBuilder.Entity<BookingRequest>().ToTable("BookingRequests");

        modelBuilder.Entity<Setting>()
            .HasIndex(s => s.SettingKey)
            .IsUnique();

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

        modelBuilder.Entity<BookingRequest>()
            .HasIndex(b => b.Reference)
            .IsUnique();

        modelBuilder.Entity<BookingRequest>()
            .HasOne(b => b.Car)
            .WithMany()
            .HasForeignKey(b => b.CarId)
            .OnDelete(DeleteBehavior.Restrict);

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
        modelBuilder.Entity<CarCategory>().HasData(
            new CarCategory { CategoryId = 1, CategoryName = "Economy", Description = "Affordable compact cars for city driving", BaseDailyRate = 25m, IsActive = true },
            new CarCategory { CategoryId = 2, CategoryName = "SUV", Description = "Family and adventure SUVs", BaseDailyRate = 55m, IsActive = true },
            new CarCategory { CategoryId = 3, CategoryName = "Luxury", Description = "Premium vehicles with high comfort", BaseDailyRate = 120m, IsActive = true },
            new CarCategory { CategoryId = 4, CategoryName = "Compact", Description = "Small cars ideal for parking and short trips", BaseDailyRate = 22m, IsActive = true },
            new CarCategory { CategoryId = 5, CategoryName = "Sedan", Description = "Comfortable mid-size sedans", BaseDailyRate = 35m, IsActive = true },
            new CarCategory { CategoryId = 6, CategoryName = "Hatchback", Description = "Practical hatchbacks for daily use", BaseDailyRate = 28m, IsActive = true },
            new CarCategory { CategoryId = 7, CategoryName = "Convertible", Description = "Open-top cars for leisure driving", BaseDailyRate = 95m, IsActive = true },
            new CarCategory { CategoryId = 8, CategoryName = "Pickup", Description = "Utility pickup trucks for cargo and travel", BaseDailyRate = 50m, IsActive = true },
            new CarCategory { CategoryId = 9, CategoryName = "Van", Description = "Passenger vans for groups and tours", BaseDailyRate = 70m, IsActive = true },
            new CarCategory { CategoryId = 10, CategoryName = "Minivan", Description = "Family minivans with extra space", BaseDailyRate = 60m, IsActive = true },
            new CarCategory { CategoryId = 11, CategoryName = "Electric", Description = "Eco-friendly electric vehicles", BaseDailyRate = 65m, IsActive = true },
            new CarCategory { CategoryId = 12, CategoryName = "Hybrid", Description = "Fuel-efficient hybrid cars", BaseDailyRate = 45m, IsActive = true },
            new CarCategory { CategoryId = 13, CategoryName = "Sports", Description = "High-performance sports cars", BaseDailyRate = 150m, IsActive = true },
            new CarCategory { CategoryId = 14, CategoryName = "Premium SUV", Description = "Luxury SUVs with advanced features", BaseDailyRate = 110m, IsActive = true },
            new CarCategory { CategoryId = 15, CategoryName = "Business", Description = "Executive cars for business travel", BaseDailyRate = 85m, IsActive = true });

        DemoSeedData.Apply(modelBuilder);
    }
}
