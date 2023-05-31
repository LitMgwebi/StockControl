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
    public class Purchase_Request_DetailController : Controller
    {
        private const double tax = 0.07;
        private readonly ApplicationDbContext _context;

        public Purchase_Request_DetailController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Purchase_Request_Detail/Create
        public IActionResult Create(string RequestID)
        {
            ViewData["ProductID"] = new SelectList(_context.Products.Where(m => m.IsDeleted == false), "ProductID", "ProductName");
            ViewData["RequestID"] = RequestID;
            return View();
        }

        // POST: Purchase_Request_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestID,ProductID,Quantity")] Purchase_Request_Detail purchase_Request_Detail)
        {
            _context.Add(purchase_Request_Detail);

            var pr = await _context.Purchase_Request.FindAsync(purchase_Request_Detail.RequestID);
            var product = await _context.Products.FindAsync(purchase_Request_Detail.ProductID);
            decimal sub = pr.PurchaseRequestSubtotal.Value;
            decimal total = pr.PurchaseRequestTotal.Value;
            decimal productAmount = product.ProductPrice;

            sub = sub + (purchase_Request_Detail.Quantity * productAmount);
            total = total + sub + (sub * (decimal)tax);

            pr.PurchaseRequestSubtotal = sub;
            pr.PurchaseRequestTotal = total;
            _context.Purchase_Request.Update(pr);

            await _context.SaveChangesAsync();
            //return RedirectToAction("Index", "Purchase_Request");

            ViewData["ProductID"] = new SelectList(_context.Products.Where(m => m.IsDeleted == false), "ProductID", "ProductName");
            ViewData["RequestID"] = purchase_Request_Detail.RequestID;
            return View();
        }

        // Have a method that generates a List everytime "Confirm" is pressed
        // Have a return View when adding, and a "Finshed" button

        // GET: Purchase_Request_Detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Purchase_Request_Detail == null)
            {
                return NotFound();
            }

            var purchase_Request_Detail = await _context.Purchase_Request_Detail.FindAsync(id);
            if (purchase_Request_Detail == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products.Where(m => m.IsDeleted == false), "ProductID", "ProductID", purchase_Request_Detail.ProductID);
            ViewData["RequestID"] = purchase_Request_Detail.RequestID;
            return View(purchase_Request_Detail);
        }

        // POST: Purchase_Request_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,ProductID,Quantity")] Purchase_Request_Detail purchase_Request_Detail)
        {
            if (id != purchase_Request_Detail.RequestID)
            {
                return NotFound();
            }

            try
            {
                var pr = await _context.Purchase_Request.FindAsync(purchase_Request_Detail.RequestID);
                var product = await _context.Products.FindAsync(purchase_Request_Detail.ProductID);
                decimal sub = pr.PurchaseRequestSubtotal.Value;
                decimal total = pr.PurchaseRequestTotal.Value;
                decimal productAmount = product.ProductPrice;

                sub = sub + (purchase_Request_Detail.Quantity * productAmount);
                total = total + sub + (sub * (decimal)tax);

                pr.PurchaseRequestSubtotal = sub;
                pr.PurchaseRequestTotal = total;

                _context.Purchase_Request.Update(pr);
                _context.Update(purchase_Request_Detail);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Purchase_Request_DetailExists(purchase_Request_Detail.RequestID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", "Purchase_Request", new { id = purchase_Request_Detail.RequestID });
            /*ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", purchase_Request_Detail.ProductID);
            ViewData["RequestID"] = new SelectList(_context.Purchase_Request, "RequestID", "RequestID", purchase_Request_Detail.RequestID);
            return View(purchase_Request_Detail);*/
        }

        // GET: Purchase_Request_Detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Purchase_Request_Detail == null)
            {
                return NotFound();
            }

            var purchase_Request_Detail = await _context.Purchase_Request_Detail
                .Include(p => p.Product)
                .Include(p => p.Purchase_Request)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (purchase_Request_Detail == null)
            {
                return NotFound();
            }
            ViewData["RequestID"] = id;
            return View(purchase_Request_Detail);
        }

        // POST: Purchase_Request_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Purchase_Request_Detail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Purchase_Request_Detail'  is null.");
            }
            var purchase_Request_Detail = await _context.Purchase_Request_Detail.FindAsync(id);
            if (purchase_Request_Detail != null)
            {
                //_context.Purchase_Request_Detail.Remove(purchase_Request_Detail);
                purchase_Request_Detail.IsDeleted = true;
                _context.Purchase_Request_Detail.Update(purchase_Request_Detail);
            }

            ViewData["RequestID"] = id;
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Purchase_Request", new { id = id });
        }

        private bool Purchase_Request_DetailExists(int id)
        {
            return (_context.Purchase_Request_Detail?.Any(e => e.RequestID == id)).GetValueOrDefault();
        }
    }
}
