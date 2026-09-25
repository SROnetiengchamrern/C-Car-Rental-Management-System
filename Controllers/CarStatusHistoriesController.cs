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
    public class CarStatusHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarStatusHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarStatusHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CarStatusHistories.Include(c => c.Car).Include(c => c.ChangedByEmployee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CarStatusHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carStatusHistory = await _context.CarStatusHistories
                .Include(c => c.Car)
                .Include(c => c.ChangedByEmployee)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (carStatusHistory == null)
            {
                return NotFound();
            }

            return View(carStatusHistory);
        }

        // GET: CarStatusHistories/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate");
            ViewData["ChangedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            return View();
        }

        // POST: CarStatusHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,CarId,PreviousStatus,NewStatus,ChangedAt,ChangedByEmployeeId,Reason,Notes")] CarStatusHistory carStatusHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carStatusHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carStatusHistory.CarId);
            ViewData["ChangedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carStatusHistory.ChangedByEmployeeId);
            return View(carStatusHistory);
        }

        // GET: CarStatusHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carStatusHistory = await _context.CarStatusHistories.FindAsync(id);
            if (carStatusHistory == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carStatusHistory.CarId);
            ViewData["ChangedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carStatusHistory.ChangedByEmployeeId);
            return View(carStatusHistory);
        }

        // POST: CarStatusHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoryId,CarId,PreviousStatus,NewStatus,ChangedAt,ChangedByEmployeeId,Reason,Notes")] CarStatusHistory carStatusHistory)
        {
            if (id != carStatusHistory.HistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carStatusHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarStatusHistoryExists(carStatusHistory.HistoryId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carStatusHistory.CarId);
            ViewData["ChangedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carStatusHistory.ChangedByEmployeeId);
            return View(carStatusHistory);
        }

        // GET: CarStatusHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carStatusHistory = await _context.CarStatusHistories
                .Include(c => c.Car)
                .Include(c => c.ChangedByEmployee)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (carStatusHistory == null)
            {
                return NotFound();
            }

            return View(carStatusHistory);
        }

        // POST: CarStatusHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carStatusHistory = await _context.CarStatusHistories.FindAsync(id);
            if (carStatusHistory != null)
            {
                _context.CarStatusHistories.Remove(carStatusHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarStatusHistoryExists(int id)
        {
            return _context.CarStatusHistories.Any(e => e.HistoryId == id);
        }
    }
}
