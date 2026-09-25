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
    public class RentalContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalContracts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RentalContracts.Include(r => r.Branch).Include(r => r.Customer).Include(r => r.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RentalContracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalContract = await _context.RentalContracts
                .Include(r => r.Branch)
                .Include(r => r.Customer)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (rentalContract == null)
            {
                return NotFound();
            }

            return View(rentalContract);
        }

        // GET: RentalContracts/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            return View();
        }

        // POST: RentalContracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractId,CustomerId,EmployeeId,BranchId,ContractNumber,StartDate,EndDate,Status,TotalAmount,DepositAmount,Notes,CreatedAt")] RentalContract rentalContract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalContract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", rentalContract.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", rentalContract.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", rentalContract.EmployeeId);
            return View(rentalContract);
        }

        // GET: RentalContracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalContract = await _context.RentalContracts.FindAsync(id);
            if (rentalContract == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", rentalContract.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", rentalContract.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", rentalContract.EmployeeId);
            return View(rentalContract);
        }

        // POST: RentalContracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractId,CustomerId,EmployeeId,BranchId,ContractNumber,StartDate,EndDate,Status,TotalAmount,DepositAmount,Notes,CreatedAt")] RentalContract rentalContract)
        {
            if (id != rentalContract.ContractId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalContract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalContractExists(rentalContract.ContractId))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", rentalContract.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", rentalContract.CustomerId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", rentalContract.EmployeeId);
            return View(rentalContract);
        }

        // GET: RentalContracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalContract = await _context.RentalContracts
                .Include(r => r.Branch)
                .Include(r => r.Customer)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.ContractId == id);
            if (rentalContract == null)
            {
                return NotFound();
            }

            return View(rentalContract);
        }

        // POST: RentalContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalContract = await _context.RentalContracts.FindAsync(id);
            if (rentalContract != null)
            {
                _context.RentalContracts.Remove(rentalContract);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalContractExists(int id)
        {
            return _context.RentalContracts.Any(e => e.ContractId == id);
        }
    }
}
