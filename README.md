# Car Rental Management System

ASP.NET Core MVC + Entity Framework Core + SQL Server application for managing a car rental business.

## Stack

- .NET 10 / ASP.NET Core MVC
- Entity Framework Core 10
- SQL Server (`CarRentalManagementSystem`)

## Database tables

1. CarCategories
2. Cars
3. Customers
4. Branches
5. Employees
6. RentalContracts
7. RentalContractDetails
8. Payments
9. CarReturns
10. ReturnInspections
11. CarMaintenance
12. CarStatusHistory

## Connection string

Configured in `appsettings.json`:

```
Server=.;Database=CarRentalManagementSystem;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB, Express, or full) with Windows Authentication
- Database engine reachable as `Server=.`

## Run

```bash
dotnet restore
dotnet ef database update
dotnet run
```

On startup the app applies EF migrations automatically and seeds sample branches, categories, employees, customers, and cars.

Open: `https://localhost:7xxx` (port shown in the console).

## Modules

| Module | Features |
|--------|----------|
| Dashboard | Fleet / contract / payment overview |
| Fleet | Cars, categories, maintenance, status history |
| People | Customers, employees, branches |
| Rentals | Contracts, contract details, payments |
| Returns | Car returns and inspections |

## Useful EF commands

```bash
dotnet ef migrations add MigrationName
dotnet ef database update
dotnet ef database drop
```

## Project structure

```
Controllers/     MVC controllers (CRUD for all entities)
Data/            ApplicationDbContext + seed data
Models/          Entity models for all 12 tables
Views/           Razor views
ViewModels/      Dashboard view model
Database/        Optional SQL scripts
```
