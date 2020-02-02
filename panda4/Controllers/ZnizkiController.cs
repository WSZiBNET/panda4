using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using panda4.Models;

namespace panda4.Controllers
{
    public class ZnizkiController : Controller
    {
        private readonly KomputerContext _context;

        public ZnizkiController(KomputerContext context)
        {
            _context = context;
        }

        // GET: Znizki
        public async Task<IActionResult> Index()
        {
            return View(await _context.Znizki.ToListAsync());
        }

        // GET: Znizki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znizkiModel = await _context.Znizki
                .FirstOrDefaultAsync(m => m.ZnizkiId == id);
            if (znizkiModel == null)
            {
                return NotFound();
            }

            return View(znizkiModel);
        }

        // GET: Znizki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Znizki/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZnizkiId,UzytkownikId,Znizka")] ZnizkiModel znizkiModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(znizkiModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(znizkiModel);
        }

        // GET: Znizki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znizkiModel = await _context.Znizki.FindAsync(id);
            if (znizkiModel == null)
            {
                return NotFound();
            }
            return View(znizkiModel);
        }

        // POST: Znizki/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZnizkiId,UzytkownikId,Znizka")] ZnizkiModel znizkiModel)
        {
            if (id != znizkiModel.ZnizkiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(znizkiModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZnizkiModelExists(znizkiModel.ZnizkiId))
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
            return View(znizkiModel);
        }

        // GET: Znizki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znizkiModel = await _context.Znizki
                .FirstOrDefaultAsync(m => m.ZnizkiId == id);
            if (znizkiModel == null)
            {
                return NotFound();
            }

            return View(znizkiModel);
        }

        // POST: Znizki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var znizkiModel = await _context.Znizki.FindAsync(id);
            _context.Znizki.Remove(znizkiModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZnizkiModelExists(int id)
        {
            return _context.Znizki.Any(e => e.ZnizkiId == id);
        }
    }
}
