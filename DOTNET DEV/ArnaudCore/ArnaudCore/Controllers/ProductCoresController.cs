using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArnaudCore.Data;
using ArnaudCore.Models;

namespace ArnaudCore.Controllers
{
    public class ProductCoresController : Controller
    {
        private readonly ShopDbContext _context;

        public ProductCoresController(ShopDbContext context)
        {
            _context = context;    
        }

        // GET: ProductCores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: ProductCores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCore = await _context.Products
                .SingleOrDefaultAsync(m => m.ID == id);
            if (productCore == null)
            {
                return NotFound();
            }

            return View(productCore);
        }

        // GET: ProductCores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Price,ImageName")] ProductCore productCore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCore);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productCore);
        }

        // GET: ProductCores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCore = await _context.Products.SingleOrDefaultAsync(m => m.ID == id);
            if (productCore == null)
            {
                return NotFound();
            }
            return View(productCore);
        }

        // POST: ProductCores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Price,ImageName")] ProductCore productCore)
        {
            if (id != productCore.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCoreExists(productCore.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(productCore);
        }

        // GET: ProductCores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCore = await _context.Products
                .SingleOrDefaultAsync(m => m.ID == id);
            if (productCore == null)
            {
                return NotFound();
            }

            return View(productCore);
        }

        // POST: ProductCores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productCore = await _context.Products.SingleOrDefaultAsync(m => m.ID == id);
            _context.Products.Remove(productCore);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductCoreExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
