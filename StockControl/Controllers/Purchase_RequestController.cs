using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockControl.Data;
using StockControl.Models;

namespace StockControl.Controllers
{
    public class Purchase_RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Purchase_RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchase_Request
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Purchase_Request.Include(p => p.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Purchase_Request/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Purchase_Request == null)
            {
                return NotFound();
            }

            var purchase_Request = await _context.Purchase_Request
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (purchase_Request == null)
            {
                return NotFound();
            }

            return View(purchase_Request);
        }

        // GET: Purchase_Request/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeName");
            return View();
        }

        // POST: Purchase_Request/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,RequestDate,EmployeeID,PurchaseRequestStatus,PurchaseRequestTotal,PurchaseRequestSubtotal")] Purchase_Request purchase_Request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase_Request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeName", purchase_Request.EmployeeID);
            return View(purchase_Request);
        }

        // GET: Purchase_Request/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Purchase_Request == null)
            {
                return NotFound();
            }

            var purchase_Request = await _context.Purchase_Request.FindAsync(id);
            if (purchase_Request == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", purchase_Request.EmployeeID);
            return View(purchase_Request);
        }

        // POST: Purchase_Request/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,RequestDate,EmployeeID,PurchaseRequestStatus,PurchaseRequestTotal,PurchaseRequestSubtotal")] Purchase_Request purchase_Request)
        {
            if (id != purchase_Request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase_Request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Purchase_RequestExists(purchase_Request.RequestID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", purchase_Request.EmployeeID);
            return View(purchase_Request);
        }

        // GET: Purchase_Request/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Purchase_Request == null)
            {
                return NotFound();
            }

            var purchase_Request = await _context.Purchase_Request
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (purchase_Request == null)
            {
                return NotFound();
            }

            return View(purchase_Request);
        }

        // POST: Purchase_Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Purchase_Request == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Purchase_Request'  is null.");
            }
            var purchase_Request = await _context.Purchase_Request.FindAsync(id);
            if (purchase_Request != null)
            {
                _context.Purchase_Request.Remove(purchase_Request);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Purchase_RequestExists(int id)
        {
          return (_context.Purchase_Request?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
