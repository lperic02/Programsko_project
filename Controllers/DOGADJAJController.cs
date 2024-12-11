using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programsko.Data;
using Programsko.Models;

namespace Programsko.Controllers
{
    public class DOGADJAJController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DOGADJAJController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DOGADJAJ
        public async Task<IActionResult> Index()
        {
            return View(await _context.DOGADJAJ.ToListAsync());
        }

        // GET: DOGADJAJ/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var DOGADJAJ = await _context.DOGADJAJ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (DOGADJAJ == null)
            {
                return NotFound();
            }

            return View(DOGADJAJ);
        }

        // GET: DOGADJAJ/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DOGADJAJ/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DATUM,KONTAKT,TIP_DOGADJAJA,ID_DG,ID_DC,ID_DS,ID_OSTALO,ID_IZVJESTAJ,ID_AUTOMOBILI,ID_SALON,ID_CATERING")] DOGADJAJ dOGADJAJ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dOGADJAJ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dOGADJAJ);
        }

        // GET: DOGADJAJ/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dOGADJAJ = await _context.DOGADJAJ.FindAsync(id);
            if (dOGADJAJ == null)
            {
                return NotFound();
            }
            return View(dOGADJAJ);
        }

        // POST: DOGADJAJ/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DATUM,KONTAKT,TIP_DOGADJAJA,ID_DG,ID_DC,ID_DS,ID_OSTALO,ID_IZVJESTAJ,ID_AUTOMOBILI,ID_SALON,ID_CATERING")] DOGADJAJ dOGADJAJ)
        {
            if (id != dOGADJAJ.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dOGADJAJ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DOGADJAJExists(dOGADJAJ.Id))
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
            return View(dOGADJAJ);
        }

        // GET: DOGADJAJ/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dOGADJAJ = await _context.DOGADJAJ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dOGADJAJ == null)
            {
                return NotFound();
            }

            return View(dOGADJAJ);
        }

        // POST: DOGADJAJ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dOGADJAJ = await _context.DOGADJAJ.FindAsync(id);
            if (dOGADJAJ != null)
            {
                _context.DOGADJAJ.Remove(dOGADJAJ);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DOGADJAJExists(int id)
        {
            return _context.DOGADJAJ.Any(e => e.Id == id);
        }
    }
}
