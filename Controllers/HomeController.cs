using System.Diagnostics;
using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.Models;
using CarRentalManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var recentBookings = await _context.BookingRequests
            .AsNoTracking()
            .Include(b => b.Car)
            .OrderByDescending(b => b.CreatedAt)
            .Take(8)
            .Select(b => new DashboardBookingItem
            {
                BookingRequestId = b.BookingRequestId,
                Reference = b.Reference,
                FullName = b.FullName,
                CarName = b.Car != null ? b.Car.Make + " " + b.Car.Model : ("#" + b.CarId),
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                Status = b.Status,
                CreatedAt = b.CreatedAt
            })
            .ToListAsync();

        var today = DateTime.Today;
        var dueUntil = today.AddDays(7);

        var upcomingReturns = await _context.RentalContracts
            .AsNoTracking()
            .Include(c => c.Customer)
            .Where(c => c.Status == "Active" && c.EndDate.Date >= today && c.EndDate.Date <= dueUntil)
            .OrderBy(c => c.EndDate)
            .Take(5)
            .Select(c => new DashboardReturnDueItem
            {
                ContractId = c.ContractId,
                ContractNumber = c.ContractNumber,
                CustomerName = c.Customer != null
                    ? c.Customer.FirstName + " " + c.Customer.LastName
                    : "—",
                EndDate = c.EndDate
            })
            .ToListAsync();

        var model = new DashboardViewModel
        {
            TotalCars = await _context.Cars.CountAsync(),
            AvailableCars = await _context.Cars.CountAsync(c => c.Status == "Available"),
            RentedCars = await _context.Cars.CountAsync(c => c.Status == "Rented"),
            TotalCustomers = await _context.Customers.CountAsync(),
            ActiveContracts = await _context.RentalContracts.CountAsync(c => c.Status == "Active"),
            TotalBranches = await _context.Branches.CountAsync(b => b.IsActive),
            TotalEmployees = await _context.Employees.CountAsync(e => e.IsActive),
            PendingMaintenance = await _context.CarMaintenances.CountAsync(m => m.Status == "Scheduled" || m.Status == "InProgress"),
            CarsInMaintenance = await _context.Cars.CountAsync(c => c.Status == "Maintenance" || c.Status == "OutOfService"),
            NewBookingRequests = await _context.BookingRequests.CountAsync(b => b.Status == "New"),
            TotalBookingRequests = await _context.BookingRequests.CountAsync(),
            ReturnsDueSoon = upcomingReturns.Count,
            TotalPayments = await _context.Payments
                .Where(p => p.Status == "Completed")
                .SumAsync(p => (decimal?)p.Amount) ?? 0m,
            RecentBookings = recentBookings,
            UpcomingReturns = upcomingReturns
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
