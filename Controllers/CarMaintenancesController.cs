using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementSystem.Data;
using CarRentalManagementSystem.Models;

namespace CarRentalManagementSystem.Controllers
{
    public class CarMaintenancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarMaintenancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarMaintenances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CarMaintenances.Include(c => c.Car).Include(c => c.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CarMaintenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMaintenance = await _context.CarMaintenances
                .Include(c => c.Car)
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(m => m.MaintenanceId == id);
            if (carMaintenance == null)
            {
                return NotFound();
            }

            return View(carMaintenance);
        }

        // GET: CarMaintenances/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            return View();
        }

        // POST: CarMaintenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaintenanceId,CarId,EmployeeId,MaintenanceType,Description,StartDate,EndDate,Cost,Status,ServiceProvider,Notes")] CarMaintenance carMaintenance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carMaintenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carMaintenance.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carMaintenance.EmployeeId);
            return View(carMaintenance);
        }

        // GET: CarMaintenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMaintenance = await _context.CarMaintenances.FindAsync(id);
            if (carMaintenance == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carMaintenance.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carMaintenance.EmployeeId);
            return View(carMaintenance);
        }

        // POST: CarMaintenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaintenanceId,CarId,EmployeeId,MaintenanceType,Description,StartDate,EndDate,Cost,Status,ServiceProvider,Notes")] CarMaintenance carMaintenance)
        {
            if (id != carMaintenance.MaintenanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carMaintenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarMaintenanceExists(carMaintenance.MaintenanceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carMaintenance.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carMaintenance.EmployeeId);
            return View(carMaintenance);
        }

        // GET: CarMaintenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carMaintenance = await _context.CarMaintenances
                .Include(c => c.Car)
                .Include(c => c.Employee)
                .FirstOrDefaultAsync(m => m.MaintenanceId == id);
            if (carMaintenance == null)
            {
                return NotFound();
            }

            return View(carMaintenance);
        }

        // POST: CarMaintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carMaintenance = await _context.CarMaintenances.FindAsync(id);
            if (carMaintenance != null)
            {
                _context.CarMaintenances.Remove(carMaintenance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarMaintenanceExists(int id)
        {
            return _context.CarMaintenances.Any(e => e.MaintenanceId == id);
        }
    }
}
