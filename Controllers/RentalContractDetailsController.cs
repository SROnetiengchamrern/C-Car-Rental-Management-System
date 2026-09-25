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
    public class RentalContractDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalContractDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalContractDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentalContractDetails.Include(r => r.Car).Include(r => r.RentalContract);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentalContractDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalContractDetail = await _context.RentalContractDetails
                .Include(r => r.Car)
                .Include(r => r.RentalContract)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (rentalContractDetail == null)
            {
                return NotFound();
            }

            return View(rentalContractDetail);
        }

        // GET: RentalContractDetails/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate");
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber");
            return View();
        }

        // POST: RentalContractDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailId,ContractId,CarId,DailyRate,Days,SubTotal,Notes")] RentalContractDetail rentalContractDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalContractDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", rentalContractDetail.CarId);
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber", rentalContractDetail.ContractId);
            return View(rentalContractDetail);
        }

        // GET: RentalContractDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalContractDetail = await _context.RentalContractDetails.FindAsync(id);
            if (rentalContractDetail == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", rentalContractDetail.CarId);
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber", rentalContractDetail.ContractId);
            return View(rentalContractDetail);
        }

        // POST: RentalContractDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailId,ContractId,CarId,DailyRate,Days,SubTotal,Notes")] RentalContractDetail rentalContractDetail)
        {
            if (id != rentalContractDetail.DetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalContractDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalContractDetailExists(rentalContractDetail.DetailId))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "CarId", "LicensePlate", rentalContractDetail.CarId);
            ViewData["ContractId"] = new SelectList(_context.RentalContracts, "ContractId", "ContractNumber", rentalContractDetail.ContractId);
            return View(rentalContractDetail);
        }

        // GET: RentalContractDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalContractDetail = await _context.RentalContractDetails
                .Include(r => r.Car)
                .Include(r => r.RentalContract)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (rentalContractDetail == null)
            {
                return NotFound();
            }

            return View(rentalContractDetail);
        }

        // POST: RentalContractDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalContractDetail = await _context.RentalContractDetails.FindAsync(id);
            if (rentalContractDetail != null)
            {
                _context.RentalContractDetails.Remove(rentalContractDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalContractDetailExists(int id)
        {
            return _context.RentalContractDetails.Any(e => e.DetailId == id);
        }
    }
}
