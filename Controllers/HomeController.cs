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
            TotalPayments = await _context.Payments
                .Where(p => p.Status == "Completed")
                .SumAsync(p => (decimal?)p.Amount) ?? 0m
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
