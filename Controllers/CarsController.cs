using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Controllers;

public class CarsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;
    private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png", ".gif", ".webp"];

    public CarsController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public async Task<IActionResult> Index()
    {
        var cars = _context.Cars.Include(c => c.Branch).Include(c => c.Category);
        return View(await cars.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars
            .Include(c => c.Branch)
            .Include(c => c.Category)
            .FirstOrDefaultAsync(m => m.CarId == id);
        if (car == null) return NotFound();

        return View(car);
    }

    public IActionResult Create()
    {
        PopulateLookups();
        return View(new Car
        {
            Status = "Available",
            Seats = 5,
            Transmission = "Automatic",
            FuelType = "Gasoline",
            Year = DateTime.Now.Year,
            CreatedAt = DateTime.Now
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Car car, IFormFile? imageFile)
    {
        if (imageFile is { Length: > 0 })
        {
            var savedPath = await SaveCarImageAsync(imageFile);
            if (savedPath is null)
            {
                ModelState.AddModelError("ImageUrl", "Please choose a valid image (jpg, jpeg, png, gif, webp).");
            }
            else
            {
                car.ImageUrl = savedPath;
            }
        }

        if (ModelState.IsValid)
        {
            car.CreatedAt = DateTime.Now;
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(car.BranchId, car.CategoryId);
        return View(car);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();

        PopulateLookups(car.BranchId, car.CategoryId);
        return View(car);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Car car, IFormFile? imageFile)
    {
        if (id != car.CarId) return NotFound();

        var existing = await _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.CarId == id);
        if (existing == null) return NotFound();

        if (imageFile is { Length: > 0 })
        {
            var savedPath = await SaveCarImageAsync(imageFile);
            if (savedPath is null)
            {
                ModelState.AddModelError("ImageUrl", "Please choose a valid image (jpg, jpeg, png, gif, webp).");
            }
            else
            {
                DeleteLocalImage(existing.ImageUrl);
                car.ImageUrl = savedPath;
            }
        }
        else if (string.IsNullOrWhiteSpace(car.ImageUrl))
        {
            car.ImageUrl = existing.ImageUrl;
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(car.CarId)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        PopulateLookups(car.BranchId, car.CategoryId);
        return View(car);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars
            .Include(c => c.Branch)
            .Include(c => c.Category)
            .FirstOrDefaultAsync(m => m.CarId == id);
        if (car == null) return NotFound();

        return View(car);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            DeleteLocalImage(car.ImageUrl);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private void PopulateLookups(int? branchId = null, int? categoryId = null)
    {
        ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "BranchName", branchId);
        ViewData["CategoryId"] = new SelectList(_context.CarCategories, "CategoryId", "CategoryName", categoryId);
    }

    private async Task<string?> SaveCarImageAsync(IFormFile imageFile)
    {
        var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
        if (!AllowedExtensions.Contains(extension))
        {
            return null;
        }

        if (imageFile.Length > 5 * 1024 * 1024)
        {
            return null;
        }

        var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "cars");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid():N}{extension}";
        var fullPath = Path.Combine(uploadsFolder, fileName);

        await using var stream = new FileStream(fullPath, FileMode.Create);
        await imageFile.CopyToAsync(stream);

        return $"/uploads/cars/{fileName}";
    }

    private void DeleteLocalImage(string? imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl) || !imageUrl.StartsWith("/uploads/cars/", StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        var fullPath = Path.Combine(_env.WebRootPath, imageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
        if (System.IO.File.Exists(fullPath))
        {
            System.IO.File.Delete(fullPath);
        }
    }

    private bool CarExists(int id) => _context.Cars.Any(e => e.CarId == id);
}
