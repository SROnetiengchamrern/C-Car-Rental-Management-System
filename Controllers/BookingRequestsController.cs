using CarRentalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Controllers;

public class BookingRequestsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingRequestsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _context.BookingRequests
            .AsNoTracking()
            .Include(b => b.Car)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync();
        return View(items);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.BookingRequests
            .AsNoTracking()
            .Include(b => b.Car)
                .ThenInclude(c => c!.Category)
            .Include(b => b.Car)
                .ThenInclude(c => c!.Branch)
            .FirstOrDefaultAsync(b => b.BookingRequestId == id);

        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(int id, string status)
    {
        var allowed = new[] { "New", "Contacted", "Confirmed", "Cancelled" };
        if (!allowed.Contains(status))
        {
            TempData["Error"] = "Invalid status.";
            return RedirectToAction(nameof(Details), new { id });
        }

        var item = await _context.BookingRequests.FindAsync(id);
        if (item == null) return NotFound();

        item.Status = status;
        await _context.SaveChangesAsync();
        TempData["Success"] = $"Status updated to {status}.";
        return RedirectToAction(nameof(Details), new { id });
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var item = await _context.BookingRequests
            .AsNoTracking()
            .Include(b => b.Car)
            .FirstOrDefaultAsync(b => b.BookingRequestId == id);

        if (item == null) return NotFound();
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.BookingRequests.FindAsync(id);
        if (item != null)
        {
            _context.BookingRequests.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Poll endpoint for admin toast alerts. Pass afterId from localStorage.
    /// First call with afterId=0 returns maxId only (baseline, no alerts).
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Alerts(int afterId = 0)
    {
        var maxId = await _context.BookingRequests
            .Select(b => (int?)b.BookingRequestId)
            .MaxAsync() ?? 0;

        var newCount = await _context.BookingRequests
            .CountAsync(b => b.Status == "New");

        if (afterId <= 0)
        {
            return Json(new
            {
                maxId,
                newCount,
                items = Array.Empty<object>()
            });
        }

        var items = await _context.BookingRequests
            .AsNoTracking()
            .Include(b => b.Car)
            .Where(b => b.BookingRequestId > afterId)
            .OrderBy(b => b.BookingRequestId)
            .Select(b => new
            {
                b.BookingRequestId,
                b.Reference,
                b.FullName,
                b.Email,
                b.Phone,
                b.StartDate,
                b.EndDate,
                b.Status,
                b.CreatedAt,
                CarName = b.Car != null ? b.Car.Make + " " + b.Car.Model : ("#" + b.CarId)
            })
            .ToListAsync();

        return Json(new
        {
            maxId = items.Count > 0 ? items[^1].BookingRequestId : maxId,
            newCount,
            items
        });
    }
}
