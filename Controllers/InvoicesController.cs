using System.Linq;
using System.Threading.Tasks;
using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Controllers;

public class InvoicesController : Controller
{
    private readonly ApplicationDbContext _context;

    public InvoicesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var contracts = await _context.RentalContracts
            .AsNoTracking()
            .Include(c => c.Customer)
            .Include(c => c.Branch)
            .Include(c => c.RentalContractDetails)
                .ThenInclude(d => d.Car)
            .Include(c => c.Payments)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        var invoices = contracts.Select(c =>
        {
            var subTotal = c.RentalContractDetails.Sum(d => d.SubTotal);
            var paid = c.Payments
                .Where(p => string.Equals(p.Status, "Completed", StringComparison.OrdinalIgnoreCase))
                .Sum(p => p.Amount);
            // Sample layout:
            // Total Due = Sub Total − Discount
            // Total     = Total Due − Deposit (Paid)
            var totalDue = Math.Max(0, subTotal - c.DiscountAmount);
            var total = Math.Max(0, totalDue - c.DepositAmount);
            var cars = c.RentalContractDetails
                .Where(d => d.Car != null)
                .Select(d => $"{d.Car!.Make} {d.Car.Model} ({d.Car.LicensePlate})")
                .ToList();

            return new InvoiceListItemViewModel
            {
                ContractId = c.ContractId,
                InvoiceNumber = ToInvoiceNumber(c.ContractNumber),
                CustomerName = c.Customer?.FullName ?? "—",
                BranchName = c.Branch?.BranchName ?? "—",
                InvoiceDate = c.CreatedAt,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                SubTotal = subTotal,
                DiscountAmount = c.DiscountAmount,
                TotalDue = totalDue,
                DepositAmount = c.DepositAmount,
                TotalAmount = total,
                PaidAmount = paid,
                Status = c.Status,
                CarsSummary = cars.Count > 0 ? string.Join(", ", cars) : "—"
            };
        }).ToList();

        return View(invoices);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var contract = await _context.RentalContracts
            .AsNoTracking()
            .Include(c => c.Customer)
            .Include(c => c.Branch)
            .Include(c => c.Employee)
            .Include(c => c.RentalContractDetails)
                .ThenInclude(d => d.Car)
            .Include(c => c.Payments)
                .ThenInclude(p => p.ReceivedByEmployee)
            .FirstOrDefaultAsync(c => c.ContractId == id);

        if (contract == null) return NotFound();

        var lines = contract.RentalContractDetails.OrderBy(d => d.DetailId).ToList();
        var payments = contract.Payments.OrderBy(p => p.PaymentDate).ToList();
        var subTotal = lines.Sum(d => d.SubTotal);
        var paid = payments
            .Where(p => string.Equals(p.Status, "Completed", StringComparison.OrdinalIgnoreCase))
            .Sum(p => p.Amount);
        // Sample layout:
        // Total Due = Sub Total − Discount
        // Total     = Total Due − Deposit (Paid)
        var totalDue = Math.Max(0, subTotal - contract.DiscountAmount);
        var total = Math.Max(0, totalDue - contract.DepositAmount);

        var model = new InvoiceDetailViewModel
        {
            InvoiceNumber = ToInvoiceNumber(contract.ContractNumber),
            InvoiceDate = contract.CreatedAt,
            Contract = contract,
            SubTotal = subTotal,
            DiscountAmount = contract.DiscountAmount,
            TotalDue = totalDue,
            DepositAmount = contract.DepositAmount,
            TotalAmount = total,
            PaidAmount = paid,
            Lines = lines,
            Payments = payments
        };

        return View(model);
    }

    private static string ToInvoiceNumber(string contractNumber)
    {
        if (string.IsNullOrWhiteSpace(contractNumber))
        {
            return "INV-UNKNOWN";
        }

        return contractNumber.StartsWith("RC-", StringComparison.OrdinalIgnoreCase)
            ? "INV-" + contractNumber[3..]
            : "INV-" + contractNumber;
    }
}
