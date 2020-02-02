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
    public class UzytkownicyController : Controller
    {
        private readonly KomputerContext _context;

        public UzytkownicyController(KomputerContext context)
        {
            _context = context;
        }

        // GET: Uzytkownicy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uzytkownicy.ToListAsync());
        }

        // GET: Uzytkownicy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicyModel = await _context.Uzytkownicy
                .FirstOrDefaultAsync(m => m.UzytkownikId == id);
            if (uzytkownicyModel == null)
            {
                return NotFound();
            }

            return View(uzytkownicyModel);
        }

        // GET: Uzytkownicy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownicy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UzytkownikId,Login,Email,CzyAdmin,Wypozyczone")] UzytkownicyModel uzytkownicyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uzytkownicyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uzytkownicyModel);
        }

        // GET: Uzytkownicy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicyModel = await _context.Uzytkownicy.FindAsync(id);
            if (uzytkownicyModel == null)
            {
                return NotFound();
            }
            return View(uzytkownicyModel);
        }

        // POST: Uzytkownicy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UzytkownikId,Login,Email,CzyAdmin,Wypozyczone")] UzytkownicyModel uzytkownicyModel)
        {
            if (id != uzytkownicyModel.UzytkownikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownicyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownicyModelExists(uzytkownicyModel.UzytkownikId))
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
            return View(uzytkownicyModel);
        }

        // GET: Uzytkownicy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownicyModel = await _context.Uzytkownicy
                .FirstOrDefaultAsync(m => m.UzytkownikId == id);
            if (uzytkownicyModel == null)
            {
                return NotFound();
            }

            return View(uzytkownicyModel);
        }

        // POST: Uzytkownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzytkownicyModel = await _context.Uzytkownicy.FindAsync(id);
            _context.Uzytkownicy.Remove(uzytkownicyModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownicyModelExists(int id)
        {
            return _context.Uzytkownicy.Any(e => e.UzytkownikId == id);
        }
    }
}
