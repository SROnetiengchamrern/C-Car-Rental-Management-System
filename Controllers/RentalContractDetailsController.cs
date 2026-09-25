using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.Models;

namespace CarRentalManagementSystem.Controllers;

public class RentalContractDetailsController : Controller
{
    private readonly ApplicationDbContext _context;

    public RentalContractDetailsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var details = _context.RentalContractDetails
            .Include(r => r.Car)
            .Include(r => r.RentalContract)
                .ThenInclude(c => c!.Customer);
        return View(await details.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var rentalContractDetail = await _context.RentalContractDetails
            .Include(r => r.Car)
            .Include(r => r.RentalContract)
                .ThenInclude(c => c!.Customer)
            .FirstOrDefaultAsync(m => m.DetailId == id);

        if (rentalContractDetail == null) return NotFound();
        return View(rentalContractDetail);
    }

    public IActionResult Create()
    {
        PopulateLookups();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RentalContractDetail rentalContractDetail)
    {
        await ApplyCalculatedAmountsAsync(rentalContractDetail);

        if (ModelState.IsValid)
        {
            _context.Add(rentalContractDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(rentalContractDetail);
        return View(rentalContractDetail);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var rentalContractDetail = await _context.RentalContractDetails.FindAsync(id);
        if (rentalContractDetail == null) return NotFound();

        PopulateLookups(rentalContractDetail);
        return View(rentalContractDetail);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, RentalContractDetail rentalContractDetail)
    {
        if (id != rentalContractDetail.DetailId) return NotFound();

        await ApplyCalculatedAmountsAsync(rentalContractDetail);

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(rentalContractDetail);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalContractDetailExists(rentalContractDetail.DetailId)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(rentalContractDetail);
        return View(rentalContractDetail);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var rentalContractDetail = await _context.RentalContractDetails
            .Include(r => r.Car)
            .Include(r => r.RentalContract)
            .FirstOrDefaultAsync(m => m.DetailId == id);
        if (rentalContractDetail == null) return NotFound();

        return View(rentalContractDetail);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var rentalContractDetail = await _context.RentalContractDetails.FindAsync(id);
        if (rentalContractDetail != null)
        {
            _context.RentalContractDetails.Remove(rentalContractDetail);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task ApplyCalculatedAmountsAsync(RentalContractDetail detail)
    {
        var car = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.CarId == detail.CarId);
        var contract = await _context.RentalContracts.AsNoTracking().FirstOrDefaultAsync(c => c.ContractId == detail.ContractId);

        if (car == null)
        {
            ModelState.AddModelError(nameof(detail.CarId), "Please choose a car.");
            return;
        }

        if (contract == null)
        {
            ModelState.AddModelError(nameof(detail.ContractId), "Please choose a contract.");
            return;
        }

        var days = (int)(contract.EndDate.Date - contract.StartDate.Date).TotalDays;
        if (days < 1) days = 1;

        detail.DailyRate = car.DailyRate;
        detail.Days = days;
        detail.SubTotal = car.DailyRate * days;

        ModelState.Remove(nameof(detail.DailyRate));
        ModelState.Remove(nameof(detail.Days));
        ModelState.Remove(nameof(detail.SubTotal));
    }

    private void PopulateLookups(RentalContractDetail? detail = null)
    {
        ViewData["CarId"] = new SelectList(
            _context.Cars
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new { c.CarId, Name = c.Make + " " + c.Model + " (" + c.LicensePlate + ")" }),
            "CarId", "Name", detail?.CarId);

        ViewData["ContractId"] = new SelectList(
            _context.RentalContracts.OrderByDescending(c => c.ContractId),
            "ContractId", "ContractNumber", detail?.ContractId);

        ViewData["CarRatesJson"] = JsonSerializer.Serialize(
            _context.Cars.AsNoTracking().ToDictionary(c => c.CarId.ToString(), c => c.DailyRate));

        ViewData["ContractDaysJson"] = JsonSerializer.Serialize(
            _context.RentalContracts.AsNoTracking().ToDictionary(
                c => c.ContractId.ToString(),
                c =>
                {
                    var days = (int)(c.EndDate.Date - c.StartDate.Date).TotalDays;
                    return days < 1 ? 1 : days;
                }));

        ViewData["ContractDiscountsJson"] = JsonSerializer.Serialize(
            _context.RentalContracts.AsNoTracking().ToDictionary(
                c => c.ContractId.ToString(),
                c => c.DiscountAmount));

        ViewData["ContractTotalsJson"] = JsonSerializer.Serialize(
            _context.RentalContracts.AsNoTracking().ToDictionary(
                c => c.ContractId.ToString(),
                c => c.TotalAmount));

        ViewData["ContractDepositsJson"] = JsonSerializer.Serialize(
            _context.RentalContracts.AsNoTracking().ToDictionary(
                c => c.ContractId.ToString(),
                c => c.DepositAmount));
    }

    private bool RentalContractDetailExists(int id) =>
        _context.RentalContractDetails.Any(e => e.DetailId == id);
}
