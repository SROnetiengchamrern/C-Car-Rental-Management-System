using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystem.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class CustomerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CustomerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("cars")]
    public async Task<ActionResult<IEnumerable<CustomerCarDto>>> GetCars(
        [FromQuery] string? status = "Available",
        [FromQuery] int? categoryId = null,
        [FromQuery] string? city = null,
        [FromQuery] string? q = null)
    {
        var query = _context.Cars
            .AsNoTracking()
            .Include(c => c.Category)
            .Include(c => c.Branch)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(status) && !string.Equals(status, "all", StringComparison.OrdinalIgnoreCase))
        {
            query = query.Where(c => c.Status == status);
        }

        if (categoryId is > 0)
        {
            query = query.Where(c => c.CategoryId == categoryId);
        }

        if (!string.IsNullOrWhiteSpace(city))
        {
            query = query.Where(c => c.Branch != null && c.Branch.City.Contains(city));
        }

        if (!string.IsNullOrWhiteSpace(q))
        {
            var term = q.Trim().ToLower();
            query = query.Where(c =>
                c.Make.ToLower().Contains(term) ||
                c.Model.ToLower().Contains(term) ||
                (c.Category != null && c.Category.CategoryName.ToLower().Contains(term)));
        }

        var cars = await query
            .OrderBy(c => c.DailyRate)
            .ToListAsync();

        return Ok(cars.Select(ToDto));
    }

    [HttpGet("cars/{id:int}")]
    public async Task<ActionResult<CustomerCarDto>> GetCar(int id)
    {
        var car = await _context.Cars
            .AsNoTracking()
            .Include(c => c.Category)
            .Include(c => c.Branch)
            .FirstOrDefaultAsync(c => c.CarId == id);

        if (car == null) return NotFound();
        return Ok(ToDto(car));
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<CustomerCategoryDto>>> GetCategories()
    {
        var categories = await _context.CarCategories
            .AsNoTracking()
            .OrderBy(c => c.CategoryName)
            .Select(c => new CustomerCategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            })
            .ToListAsync();

        return Ok(categories);
    }

    [HttpGet("branches")]
    public async Task<ActionResult<IEnumerable<CustomerBranchDto>>> GetBranches()
    {
        var branches = await _context.Branches
            .AsNoTracking()
            .Where(b => b.IsActive)
            .OrderBy(b => b.City)
            .Select(b => new CustomerBranchDto
            {
                BranchId = b.BranchId,
                BranchName = b.BranchName,
                City = b.City,
                Address = b.Address,
                Phone = b.Phone
            })
            .ToListAsync();

        return Ok(branches);
    }

    [HttpPost("booking-requests")]
    public ActionResult<object> CreateBookingRequest([FromBody] CustomerBookingRequest request)
    {
        if (request.CarId <= 0 ||
            string.IsNullOrWhiteSpace(request.FullName) ||
            string.IsNullOrWhiteSpace(request.Email) ||
            string.IsNullOrWhiteSpace(request.Phone))
        {
            return BadRequest(new { message = "Please fill name, email, phone, and car." });
        }

        if (request.EndDate.Date < request.StartDate.Date)
        {
            return BadRequest(new { message = "End date must be after start date." });
        }

        return Ok(new
        {
            message = "Booking request received. Our team will contact you shortly.",
            reference = $"BR-{DateTime.UtcNow:yyyyMMddHHmmss}-{request.CarId}"
        });
    }

    private static CustomerCarDto ToDto(Models.Car c) => new()
    {
        CarId = c.CarId,
        Make = c.Make,
        Model = c.Model,
        Year = c.Year,
        Color = c.Color,
        DailyRate = c.DailyRate,
        Status = c.Status,
        Seats = c.Seats,
        Transmission = c.Transmission,
        FuelType = c.FuelType,
        ImageUrl = c.ImageUrl,
        CategoryName = c.Category?.CategoryName ?? "",
        BranchName = c.Branch?.BranchName ?? "",
        BranchCity = c.Branch?.City ?? ""
    };
}
