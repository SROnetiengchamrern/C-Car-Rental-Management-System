using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Controllers;

public class PaymentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PaymentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var payments = _context.Payments
            .Include(p => p.ReceivedByEmployee)
            .Include(p => p.RentalContract)
                .ThenInclude(c => c!.Customer)
            .OrderByDescending(p => p.PaymentDate);
        return View(await payments.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var payment = await _context.Payments
            .Include(p => p.ReceivedByEmployee)
            .Include(p => p.RentalContract)
                .ThenInclude(c => c!.Customer)
            .FirstOrDefaultAsync(m => m.PaymentId == id);
        if (payment == null) return NotFound();

        return View(payment);
    }

    public IActionResult Create(int? contractId)
    {
        PopulateLookups(contractId: contractId);
        return View(new Payment
        {
            ContractId = contractId ?? 0,
            PaymentDate = DateTime.Now,
            PaymentMethod = "Cash",
            Status = "Completed"
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Payment payment)
    {
        if (payment.Amount <= 0)
        {
            ModelState.AddModelError(nameof(payment.Amount), "Amount must be greater than 0.");
        }

        if (ModelState.IsValid)
        {
            if (payment.PaymentDate == default)
            {
                payment.PaymentDate = DateTime.Now;
            }

            _context.Add(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(payment);
        return View(payment);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return NotFound();

        PopulateLookups(payment);
        return View(payment);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Payment payment)
    {
        if (id != payment.PaymentId) return NotFound();

        if (payment.Amount <= 0)
        {
            ModelState.AddModelError(nameof(payment.Amount), "Amount must be greater than 0.");
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(payment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(payment.PaymentId)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(payment);
        return View(payment);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var payment = await _context.Payments
            .Include(p => p.ReceivedByEmployee)
            .Include(p => p.RentalContract)
            .FirstOrDefaultAsync(m => m.PaymentId == id);
        if (payment == null) return NotFound();

        return View(payment);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment != null)
        {
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private void PopulateLookups(Payment? payment = null, int? contractId = null)
    {
        var selectedContractId = payment?.ContractId > 0 ? payment.ContractId : contractId;

        ViewData["ContractId"] = new SelectList(
            _context.RentalContracts
                .AsNoTracking()
                .Include(c => c.Customer)
                .OrderByDescending(c => c.ContractId)
                .Select(c => new
                {
                    c.ContractId,
                    Name = c.ContractNumber + " — " + c.Customer!.FirstName + " " + c.Customer.LastName
                }),
            "ContractId", "Name", selectedContractId);

        ViewData["ReceivedByEmployeeId"] = new SelectList(
            _context.Employees
                .AsNoTracking()
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.EmployeeId,
                    Name = e.FirstName + " " + e.LastName + " (" + e.Email + ")"
                }),
            "EmployeeId", "Name", payment?.ReceivedByEmployeeId);

        var contracts = _context.RentalContracts
            .AsNoTracking()
            .Include(c => c.RentalContractDetails)
            .Include(c => c.Payments)
            .ToList();

        var summary = contracts.ToDictionary(
            c => c.ContractId.ToString(),
            c =>
            {
                var subTotal = c.RentalContractDetails.Sum(d => d.SubTotal);
                // Same as invoice:
                // Total Due = Sub Total − Discount
                // Total     = Total Due − Deposit
                var totalDue = Math.Max(0, subTotal - c.DiscountAmount);
                var total = Math.Max(0, totalDue - c.DepositAmount);
                var paid = c.Payments
                    .Where(p => string.Equals(p.Status, "Completed", StringComparison.OrdinalIgnoreCase)
                                && (payment == null || p.PaymentId != payment.PaymentId))
                    .Sum(p => p.Amount);
                var remaining = Math.Max(0, totalDue - paid);
                var suggested = paid <= 0 && c.DepositAmount > 0
                    ? Math.Min(c.DepositAmount, remaining)
                    : remaining;

                return new
                {
                    subTotal,
                    discount = c.DiscountAmount,
                    totalDue,
                    deposit = c.DepositAmount,
                    total,
                    paid,
                    remaining,
                    suggested
                };
            });

        ViewData["ContractSummaryJson"] = JsonSerializer.Serialize(summary);
    }

    private bool PaymentExists(int id) =>
        _context.Payments.Any(e => e.PaymentId == id);
}
