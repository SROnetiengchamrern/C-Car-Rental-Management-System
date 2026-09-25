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
}
