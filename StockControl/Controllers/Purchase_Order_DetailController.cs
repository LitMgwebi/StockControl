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
    public class Purchase_Order_DetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Purchase_Order_DetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Purchase_Order_Detail
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Purchase_Order_Detail.Include(p => p.Product).Include(p => p.Purchase_Order);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Purchase_Order_Detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Purchase_Order_Detail == null)
            {
                return NotFound();
            }

            var purchase_Order_Detail = await _context.Purchase_Order_Detail
                .Include(p => p.Product)
                .Include(p => p.Purchase_Order)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (purchase_Order_Detail == null)
            {
                return NotFound();
            }

            return View(purchase_Order_Detail);
        }

        // GET: Purchase_Order_Detail/Create
        public IActionResult Create(string OrderID)
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            ViewData["OrderID"] = OrderID;
            return View();
        }

        // POST: Purchase_Order_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,ProductID,Quantity,Price")] Purchase_Order_Detail purchase_Order_Detail)
        {
            _context.Add(purchase_Order_Detail);
            await _context.SaveChangesAsync();
            //return RedirectToAction("Index", "Purchase_Order");

            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            ViewData["OrderID"] = purchase_Order_Detail.OrderID;
            return View(   );
        }

        // GET: Purchase_Order_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Purchase_Order_Detail == null)
            {
                return NotFound();
            }

            var purchase_Order_Detail = await _context.Purchase_Order_Detail.FindAsync(id);
            if (purchase_Order_Detail == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", purchase_Order_Detail.ProductID);
            ViewData["OrderID"] = new SelectList(_context.Purchase_Order, "OrderID", "OrderID", purchase_Order_Detail.OrderID);
            return View(purchase_Order_Detail);
        }

        // POST: Purchase_Order_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,ProductID,Quantity,Price")] Purchase_Order_Detail purchase_Order_Detail)
        {
            if (id != purchase_Order_Detail.OrderID)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(purchase_Order_Detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Purchase_Order_DetailExists(purchase_Order_Detail.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            /*ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", purchase_Order_Detail.ProductID);
            ViewData["OrderID"] = new SelectList(_context.Purchase_Order, "OrderID", "OrderID", purchase_Order_Detail.OrderID);
            return View(purchase_Order_Detail);*/
        }

        // GET: Purchase_Order_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Purchase_Order_Detail == null)
            {
                return NotFound();
            }

            var purchase_Order_Detail = await _context.Purchase_Order_Detail
                .Include(p => p.Product)
                .Include(p => p.Purchase_Order)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (purchase_Order_Detail == null)
            {
                return NotFound();
            }

            return View(purchase_Order_Detail);
        }

        // POST: Purchase_Order_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Purchase_Order_Detail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Purchase_Order_Detail'  is null.");
            }
            var purchase_Order_Detail = await _context.Purchase_Order_Detail.FindAsync(id);
            if (purchase_Order_Detail != null)
            {
                _context.Purchase_Order_Detail.Remove(purchase_Order_Detail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Purchase_Order_DetailExists(int id)
        {
            return (_context.Purchase_Order_Detail?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
