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
    public class Purchase_OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Purchase_OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchase_Order
        public async Task<IActionResult> Index()
        {
            var stockControlContext = _context.Purchase_Order.Include(p => p.Purchase_Request).Include(p => p.Supplier);
            return View(await stockControlContext.ToListAsync());
        }

        // GET: Purchase_Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Purchase_Order == null)
            {
                return NotFound();
            }

            var purchase_Order = await _context.Purchase_Order
                .Include(p => p.Purchase_Request)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (purchase_Order == null)
            {
                return NotFound();
            }

            return View(purchase_Order);
        }

        // GET: Purchase_Order/Create
        public IActionResult Create()
        {
            ViewData["RequestID"] = new SelectList(_context.Purchase_Request, "RequestID", "RequestID");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID");
            return View();
        }

        // POST: Purchase_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OrderDate,RequestID,PurchaseOrderTotal,SupplierID,PurchaseOrderProgress")] Purchase_Order purchase_Order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase_Order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RequestID"] = new SelectList(_context.Purchase_Request, "RequestID", "RequestID", purchase_Order.RequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", purchase_Order.SupplierID);
            return View(purchase_Order);
        }

        // GET: Purchase_Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Purchase_Order == null)
            {
                return NotFound();
            }

            var purchase_Order = await _context.Purchase_Order.FindAsync(id);
            if (purchase_Order == null)
            {
                return NotFound();
            }
            ViewData["RequestID"] = new SelectList(_context.Purchase_Request, "RequestID", "RequestID", purchase_Order.RequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", purchase_Order.SupplierID);
            return View(purchase_Order);
        }

        // POST: Purchase_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderDate,RequestID,PurchaseOrderTotal,SupplierID,PurchaseOrderProgress")] Purchase_Order purchase_Order)
        {
            if (id != purchase_Order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchase_Order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Purchase_OrderExists(purchase_Order.OrderID))
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
            ViewData["RequestID"] = new SelectList(_context.Purchase_Request, "RequestID", "RequestID", purchase_Order.RequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", purchase_Order.SupplierID);
            return View(purchase_Order);
        }

        // GET: Purchase_Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Purchase_Order == null)
            {
                return NotFound();
            }

            var purchase_Order = await _context.Purchase_Order
                .Include(p => p.Purchase_Request)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (purchase_Order == null)
            {
                return NotFound();
            }

            return View(purchase_Order);
        }

        // POST: Purchase_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Purchase_Order == null)
            {
                return Problem("Entity set 'StockControlContext.Purchase_Order'  is null.");
            }
            var purchase_Order = await _context.Purchase_Order.FindAsync(id);
            if (purchase_Order != null)
            {
                _context.Purchase_Order.Remove(purchase_Order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Purchase_OrderExists(int id)
        {
          return (_context.Purchase_Order?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
