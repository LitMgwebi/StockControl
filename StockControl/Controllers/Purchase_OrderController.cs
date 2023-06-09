﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockControl.Data;
using StockControl.Models;

namespace StockControl.Controllers
{
    [Authorize(Roles ="Purchase")]
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
            var applicationDbContext = _context.Purchase_Order
                .Where(m => m.IsDeleted == false)
                .Include(p => p.Purchase_Request)
                .Include(p => p.Supplier);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Purchase_Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Purchase_Order == null)
            {
                return NotFound();
            }

            var order = await _context.Purchase_Order
                .Include(p => p.Purchase_Request)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            var details = await _context.Purchase_Order_Detail
                .Where(m => m.IsDeleted == false)
                .Where(m => m.OrderID == id)
                .Include(p => p.Product)
                .ToListAsync();

            if (order == null)
            {
                return NotFound();
            }
            OrderViewModel purchase_Order = new OrderViewModel
            {
                Purchase_Order = order,
                Order_Details = details
            };
            return View(purchase_Order);
        }

        // GET: Purchase_Order/Create
        public async Task<IActionResult> Create()
        {
            ViewData["RequestID"] = new SelectList(_context.Purchase_Request.Where(m => m.IsDeleted == false), "RequestID", "RequestID");
            ViewData["SupplierID"] = new SelectList(_context.Suppliers.Where(m => m.IsDeleted == false), "SupplierID", "SupplierName");
            var date = DateTime.Now;
            ViewData["CurrentDate"] = date;

            var requests = await _context.Purchase_Request
                .Where(m => m.IsDeleted == false)
                .Where(p => p.PurchaseRequestStatus == "Submitted")
                .ToListAsync();

            OrderRequestViewModel orderRequest = new OrderRequestViewModel
            {
                Requests = requests,
            };
            return View(orderRequest);
        }

        // POST: Purchase_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderRequestViewModel purchase_Order)
        {
   //         var purchase_Order = orderRequest.Order;
            _context.Add(purchase_Order.Order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Purchase_Order_Detail", new {OrderID = purchase_Order.Order.OrderID});
            /*ViewData["RequestID"] = new SelectList(_context.Purchase_Request, "RequestID", "RequestID", purchase_Order.RequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", purchase_Order.SupplierID);
            return View(purchase_Order);*/
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
            ViewData["RequestID"] = new SelectList(_context.Purchase_Request.Where(m => m.IsDeleted == false), "RequestID", "RequestID", purchase_Order.RequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers.Where(m => m.IsDeleted == false), "SupplierID", "SupplierID", purchase_Order.SupplierID);
            return View(purchase_Order);
        }

        // POST: Purchase_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderDate,RequestID,PurchaseOrderTotal,PurchaseOrderSubtotal,SupplierID,PurchaseOrderProgress,Comment")] Purchase_Order purchase_Order)
        {
            if (id != purchase_Order.OrderID)
            {
                return NotFound();
            }

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
            /*ViewData["RequestID"] = new SelectList(_context.Purchase_Request, "RequestID", "RequestID", purchase_Order.RequestID);
            ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "SupplierID", purchase_Order.SupplierID);
            return View(purchase_Order);*/
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
                return Problem("Entity set 'ApplicationDbContext.Purchase_Order'  is null.");
            }
            var purchase_Order = await _context.Purchase_Order.FindAsync(id);
            if (purchase_Order != null)
            {
                //_context.Purchase_Order.Remove(purchase_Order);
                purchase_Order.IsDeleted = true;
                _context.Purchase_Order.Update(purchase_Order);
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
