using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.Models;

namespace CarRentalManagementSystem.Controllers;

public class RentalContractsController : Controller
{
    private readonly ApplicationDbContext _context;

    public RentalContractsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var contracts = _context.RentalContracts
            .Include(r => r.Branch)
            .Include(r => r.Customer)
            .Include(r => r.Employee)
            .Include(r => r.RentalContractDetails)
                .ThenInclude(d => d.Car);
        return View(await contracts.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var rentalContract = await _context.RentalContracts
            .Include(r => r.Branch)
            .Include(r => r.Customer)
            .Include(r => r.Employee)
            .Include(r => r.RentalContractDetails)
                .ThenInclude(d => d.Car)
            .FirstOrDefaultAsync(m => m.ContractId == id);

        if (rentalContract == null) return NotFound();
        return View(rentalContract);
    }

    public IActionResult Create()
    {
        PopulateLookups();
        return View(new RentalContract
        {
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddDays(1),
            Status = "Active",
            CreatedAt = DateTime.Now
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RentalContract rentalContract, int carId)
    {
        if (carId <= 0)
        {
            ModelState.AddModelError("CarId", "Please choose a car.");
        }

        var car = await _context.Cars.FindAsync(carId);
        if (carId > 0 && car == null)
        {
            ModelState.AddModelError("CarId", "Selected car was not found.");
        }

        if (ModelState.IsValid && car != null)
        {
            if (rentalContract.CreatedAt == default)
            {
                rentalContract.CreatedAt = DateTime.Now;
            }

            var days = GetRentalDays(rentalContract.StartDate, rentalContract.EndDate);
            var subTotal = car.DailyRate * days;

            if (rentalContract.DiscountAmount < 0)
            {
                rentalContract.DiscountAmount = 0;
            }

            if (rentalContract.DepositAmount < 0)
            {
                rentalContract.DepositAmount = 0;
            }

            // Total = Sub Total − Discount − Deposit
            rentalContract.TotalAmount = Math.Max(0,
                subTotal - rentalContract.DiscountAmount - rentalContract.DepositAmount);

            _context.Add(rentalContract);
            await _context.SaveChangesAsync();

            _context.Add(new RentalContractDetail
            {
                ContractId = rentalContract.ContractId,
                CarId = car.CarId,
                DailyRate = car.DailyRate,
                Days = days,
                SubTotal = subTotal
            });
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(rentalContract, carId);
        return View(rentalContract);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var rentalContract = await _context.RentalContracts
            .Include(r => r.RentalContractDetails)
            .FirstOrDefaultAsync(r => r.ContractId == id);
        if (rentalContract == null) return NotFound();

        var carId = rentalContract.RentalContractDetails.OrderBy(d => d.DetailId).FirstOrDefault()?.CarId ?? 0;
        PopulateLookups(rentalContract, carId);
        return View(rentalContract);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, RentalContract rentalContract, int carId)
    {
        if (id != rentalContract.ContractId) return NotFound();

        if (carId <= 0)
        {
            ModelState.AddModelError("CarId", "Please choose a car.");
        }

        var car = await _context.Cars.FindAsync(carId);
        if (carId > 0 && car == null)
        {
            ModelState.AddModelError("CarId", "Selected car was not found.");
        }

        if (ModelState.IsValid && car != null)
        {
            try
            {
                _context.Update(rentalContract);

                var days = GetRentalDays(rentalContract.StartDate, rentalContract.EndDate);
                var subTotal = car.DailyRate * days;
                var detail = await _context.RentalContractDetails
                    .Where(d => d.ContractId == rentalContract.ContractId)
                    .OrderBy(d => d.DetailId)
                    .FirstOrDefaultAsync();

                if (detail == null)
                {
                    _context.Add(new RentalContractDetail
                    {
                        ContractId = rentalContract.ContractId,
                        CarId = car.CarId,
                        DailyRate = car.DailyRate,
                        Days = days,
                        SubTotal = subTotal
                    });
                }
                else
                {
                    detail.CarId = car.CarId;
                    detail.DailyRate = car.DailyRate;
                    detail.Days = days;
                    detail.SubTotal = subTotal;
                    _context.Update(detail);
                }

                if (rentalContract.DiscountAmount < 0)
                {
                    rentalContract.DiscountAmount = 0;
                }

                if (rentalContract.DepositAmount < 0)
                {
                    rentalContract.DepositAmount = 0;
                }

                // Total = Sub Total − Discount − Deposit
                rentalContract.TotalAmount = Math.Max(0,
                    subTotal - rentalContract.DiscountAmount - rentalContract.DepositAmount);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalContractExists(rentalContract.ContractId)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(rentalContract, carId);
        return View(rentalContract);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var rentalContract = await _context.RentalContracts
            .Include(r => r.Branch)
            .Include(r => r.Customer)
            .Include(r => r.Employee)
            .FirstOrDefaultAsync(m => m.ContractId == id);
        if (rentalContract == null) return NotFound();

        return View(rentalContract);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var rentalContract = await _context.RentalContracts
            .Include(r => r.RentalContractDetails)
            .FirstOrDefaultAsync(r => r.ContractId == id);
        if (rentalContract != null)
        {
            _context.RentalContractDetails.RemoveRange(rentalContract.RentalContractDetails);
            _context.RentalContracts.Remove(rentalContract);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private void PopulateLookups(RentalContract? contract = null, int? carId = null)
    {
        ViewData["BranchId"] = new SelectList(_context.Branches.OrderBy(b => b.BranchName), "BranchId", "BranchName", contract?.BranchId);
        ViewData["CustomerId"] = new SelectList(
            _context.Customers
                .OrderBy(c => c.FirstName)
                .Select(c => new { c.CustomerId, Name = c.FirstName + " " + c.LastName }),
            "CustomerId", "Name", contract?.CustomerId);
        ViewData["EmployeeId"] = new SelectList(
            _context.Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new { e.EmployeeId, Name = e.FirstName + " " + e.LastName + " (" + e.Email + ")" }),
            "EmployeeId", "Name", contract?.EmployeeId);
        ViewData["CarId"] = new SelectList(
            _context.Cars
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new { c.CarId, Name = c.Make + " " + c.Model + " (" + c.LicensePlate + ")" }),
            "CarId", "Name", carId);
    }

    private static int GetRentalDays(DateTime start, DateTime end)
    {
        var days = (int)(end.Date - start.Date).TotalDays;
        return days < 1 ? 1 : days;
    }

    private bool RentalContractExists(int id) =>
        _context.RentalContracts.Any(e => e.ContractId == id);
}
