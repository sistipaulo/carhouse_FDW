using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarHouse.Data;
using CarHouse.Models;

namespace CarHouse.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly CarHouseContext _context;

        public InvoicesController(CarHouseContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var carHouseContext = _context.Invoice.Include(i => i.Car).Include(i => i.Client).Include(i => i.Seller);
            return View(await carHouseContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Car)
                .Include(i => i.Client)
                .Include(i => i.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {

            var viewModel = new InvoiceFormViewModel();
            viewModel.Cars = _context.Car.ToList();
            viewModel.Clients = _context.Client.ToList();
            viewModel.Sellers = _context.Seller.ToList();
            /* ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model");
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Name"); */
            return View(viewModel);
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,CreatedDate,WarrantyDate,Value,ClientId,SellerId,CarId")] Invoice invoice)
        {

                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model", invoice.CarId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", invoice.ClientId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Name", invoice.SellerId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model", invoice.CarId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", invoice.ClientId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Name", invoice.SellerId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,CreatedDate,WarrantyDate,Value,ClientId,SellerId,CarId")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Model", invoice.CarId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", invoice.ClientId);
            ViewData["SellerId"] = new SelectList(_context.Seller, "Id", "Name", invoice.SellerId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Invoice == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Car)
                .Include(i => i.Client)
                .Include(i => i.Seller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Invoice == null)
            {
                return Problem("Entity set 'CarHouseContext.Invoice'  is null.");
            }
            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoice.Remove(invoice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
          return (_context.Invoice?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
