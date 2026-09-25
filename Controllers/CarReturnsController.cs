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
    public class CarReturnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarReturnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarReturns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CarReturns.Include(c => c.Car).Include(c => c.Employee).Include(c => c.RentalContract);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CarReturns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carReturn = await _context.CarReturns
                .Include(c => c.Car)
                .Include(c => c.Employee)
                .Include(c => c.RentalContract)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (carReturn == null)
            {
                return NotFound();
            }

            return View(carReturn);
        }

        // GET: CarReturns/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber");
            return View();
        }

        // POST: CarReturns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnId,ContractId,CarId,EmployeeId,ReturnDate,OdometerReading,FuelLevel,LateFee,DamageFee,Notes,Status")] CarReturn carReturn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carReturn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carReturn.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carReturn.EmployeeId);
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber", carReturn.ContractId);
            return View(carReturn);
        }

        // GET: CarReturns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carReturn = await _context.CarReturns.FindAsync(id);
            if (carReturn == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carReturn.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carReturn.EmployeeId);
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber", carReturn.ContractId);
            return View(carReturn);
        }

        // POST: CarReturns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnId,ContractId,CarId,EmployeeId,ReturnDate,OdometerReading,FuelLevel,LateFee,DamageFee,Notes,Status")] CarReturn carReturn)
        {
            if (id != carReturn.ReturnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carReturn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarReturnExists(carReturn.ReturnId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", carReturn.CarId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", carReturn.EmployeeId);
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber", carReturn.ContractId);
            return View(carReturn);
        }

        // GET: CarReturns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carReturn = await _context.CarReturns
                .Include(c => c.Car)
                .Include(c => c.Employee)
                .Include(c => c.RentalContract)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (carReturn == null)
            {
                return NotFound();
            }

            return View(carReturn);
        }

        // POST: CarReturns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carReturn = await _context.CarReturns.FindAsync(id);
            if (carReturn != null)
            {
                _context.CarReturns.Remove(carReturn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarReturnExists(int id)
        {
            return _context.CarReturns.Any(e => e.ReturnId == id);
        }
    }
}
