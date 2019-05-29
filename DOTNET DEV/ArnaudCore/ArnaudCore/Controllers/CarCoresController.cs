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
    public class CarCoresController : Controller
    {
        private readonly GarageFactory _context;

        public CarCoresController(GarageFactory context)
        {
            _context = context;    
        }

        // GET: CarCores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.ToListAsync());
        }

        // GET: CarCores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCore = await _context.Cars
                .SingleOrDefaultAsync(m => m.ID == id);
            if (carCore == null)
            {
                return NotFound();
            }

            return View(carCore);
        }

        // GET: CarCores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarCores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Model,MaxSpeed")] CarCore carCore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carCore);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(carCore);
        }

        // GET: CarCores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCore = await _context.Cars.SingleOrDefaultAsync(m => m.ID == id);
            if (carCore == null)
            {
                return NotFound();
            }
            return View(carCore);
        }

        // POST: CarCores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Model,MaxSpeed")] CarCore carCore)
        {
            if (id != carCore.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carCore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCoreExists(carCore.ID))
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
            return View(carCore);
        }

        // GET: CarCores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carCore = await _context.Cars
                .SingleOrDefaultAsync(m => m.ID == id);
            if (carCore == null)
            {
                return NotFound();
            }

            return View(carCore);
        }

        // POST: CarCores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carCore = await _context.Cars.SingleOrDefaultAsync(m => m.ID == id);
            _context.Cars.Remove(carCore);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CarCoreExists(int id)
        {
            return _context.Cars.Any(e => e.ID == id);
        }
    }
}
