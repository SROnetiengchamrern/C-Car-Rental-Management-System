/*
  Optional reference script.
  Prefer: dotnet ef database update
  Database is also created automatically on app startup.
*/

IF DB_ID(N'CarRentalManagementSystem') IS NULL
BEGIN
    CREATE DATABASE CarRentalManagementSystem;
END
GO

USE CarRentalManagementSystem;
GO

-- Tables (created by EF Core migration InitialCreate):
-- 1.  CarCategories
-- 2.  Cars
-- 3.  Customers
-- 4.  Branches
-- 5.  Employees
-- 6.  RentalContracts
-- 7.  RentalContractDetails
-- 8.  Payments
-- 9.  CarReturns
-- 10. ReturnInspections
-- 11. CarMaintenance
-- 12. CarStatusHistory
