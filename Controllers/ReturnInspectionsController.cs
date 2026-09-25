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
    public class ReturnInspectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReturnInspectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReturnInspections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReturnInspections.Include(r => r.CarReturn).Include(r => r.InspectedByEmployee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReturnInspections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnInspection = await _context.ReturnInspections
                .Include(r => r.CarReturn)
                .Include(r => r.InspectedByEmployee)
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (returnInspection == null)
            {
                return NotFound();
            }

            return View(returnInspection);
        }

        // GET: ReturnInspections/Create
        public IActionResult Create()
        {
            ViewData["ReturnId"] = new SelectList(_context.CarReturns, "ReturnId", "Status");
            ViewData["InspectedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            return View();
        }

        // POST: ReturnInspections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InspectionId,ReturnId,InspectedByEmployeeId,InspectionDate,ExteriorCondition,InteriorCondition,HasDamage,DamageDescription,EstimatedRepairCost,Notes")] ReturnInspection returnInspection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnInspection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReturnId"] = new SelectList(_context.CarReturns, "ReturnId", "Status", returnInspection.ReturnId);
            ViewData["InspectedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", returnInspection.InspectedByEmployeeId);
            return View(returnInspection);
        }

        // GET: ReturnInspections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnInspection = await _context.ReturnInspections.FindAsync(id);
            if (returnInspection == null)
            {
                return NotFound();
            }
            ViewData["ReturnId"] = new SelectList(_context.CarReturns, "ReturnId", "Status", returnInspection.ReturnId);
            ViewData["InspectedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", returnInspection.InspectedByEmployeeId);
            return View(returnInspection);
        }

        // POST: ReturnInspections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InspectionId,ReturnId,InspectedByEmployeeId,InspectionDate,ExteriorCondition,InteriorCondition,HasDamage,DamageDescription,EstimatedRepairCost,Notes")] ReturnInspection returnInspection)
        {
            if (id != returnInspection.InspectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnInspection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnInspectionExists(returnInspection.InspectionId))
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
            ViewData["ReturnId"] = new SelectList(_context.CarReturns, "ReturnId", "Status", returnInspection.ReturnId);
            ViewData["InspectedByEmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", returnInspection.InspectedByEmployeeId);
            return View(returnInspection);
        }

        // GET: ReturnInspections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnInspection = await _context.ReturnInspections
                .Include(r => r.CarReturn)
                .Include(r => r.InspectedByEmployee)
                .FirstOrDefaultAsync(m => m.InspectionId == id);
            if (returnInspection == null)
            {
                return NotFound();
            }

            return View(returnInspection);
        }

        // POST: ReturnInspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var returnInspection = await _context.ReturnInspections.FindAsync(id);
            if (returnInspection != null)
            {
                _context.ReturnInspections.Remove(returnInspection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnInspectionExists(int id)
        {
            return _context.ReturnInspections.Any(e => e.InspectionId == id);
        }
    }
}
