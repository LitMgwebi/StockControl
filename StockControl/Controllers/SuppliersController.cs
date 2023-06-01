using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockControl.Data;
using StockControl.Models;

namespace StockControl.Controllers
{
    [Authorize(Roles = "Purchase")]
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuppliersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
              return _context.Suppliers != null ? 
                          View(await _context.Suppliers
                            .Where(m => m.IsDeleted == false)
                            .ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Suppliers'  is null.");
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierID,SupplierName,SupplierEmail,SupplierContactNumber,SupplierAddress,SupplierUrl")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierID,SupplierName,SupplierEmail,SupplierContactNumber,SupplierAddress,SupplierUrl")] Supplier supplier)
        {
            if (id != supplier.SupplierID)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Suppliers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Suppliers'  is null.");
            }
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                //_context.Suppliers.Remove(supplier);
                supplier.IsDeleted = true;
                _context.Suppliers.Update(supplier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /*public void DownloadPDF()
        {
            Document document = new Document();
            document.Open()
            try
            {
                Paragraph heading = new Paragraph("Supplier");
                heading.SetUnderline(0.5f, -1f);
                document.Add(heading);

                Table table = new Table(2, true);
                List<Supplier> suppliers = _context.Suppliers.ToList();

                Cell cell = new Cell().Add(new Paragraph("Supplier Name"));
                cell.SetBold();
                table.AddCell(cell);
                cell = new Cell().Add(new Paragraph("Supplier Email"));
                cell.SetBold();
                table.AddCell(cell);

                foreach(var x in suppliers)
                {
                    var supplierName = new Paragraph(x.SupplierName);
                    var supplierEmail = new Paragraph(x.SupplierEmail);

                    var column1 = new Cell().Add(supplierName);
                    var column2 = new Cell().Add(supplierName);
                    table.AddCell(column1);
                    table.AddCell(column2);
                }
                DateTime currentDate = DateTime.Now;
                Paragraph dateParagraph = new Paragraph($"Created Date: {currentDate.ToString("yyyy-MM-dd")}");
                dateParagraph.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                document.Add(dateParagraph);
                document.Add(table);
            }
            catch (Exception ex)
            {

            }

        }*/
        private bool SupplierExists(int id)
        {
          return (_context.Suppliers?.Any(e => e.SupplierID == id)).GetValueOrDefault();
        }
    }
}
