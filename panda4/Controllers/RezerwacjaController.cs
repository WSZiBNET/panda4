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
    public class RezerwacjaController : Controller
    {
        private readonly KomputerContext _context;

        public RezerwacjaController(KomputerContext context)
        {
            _context = context;
        }

        // GET: Rezerwacja
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rezerwacja.ToListAsync());
        }

        // GET: Rezerwacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacjaModel = await _context.Rezerwacja
                .FirstOrDefaultAsync(m => m.RezerwacjaID == id);
            if (rezerwacjaModel == null)
            {
                return NotFound();
            }

            return View(rezerwacjaModel);
        }

        // GET: Rezerwacja/Create
        public IActionResult Create(int id)
        {
            var rezerwacjaModel = new RezerwacjaModel();
            rezerwacjaModel.KomputerID = id;
            return View(rezerwacjaModel);                    
        }


        // POST: Rezerwacja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezerwacjaID,KomputerID,UzytkownikID,DataRozpoczecia,DataZakonczenia,DataPrzedluzona")] RezerwacjaModel rezerwacjaModel)
        {
            if (ModelState.IsValid)
            {
                var komputery = await _context.KomputerModel.ToListAsync();
                if (komputery.Any(x => x.KomputerID == rezerwacjaModel.KomputerID))
                {
                    _context.Add(rezerwacjaModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Podane id komputera nie istnieje";
                }
            }
            return View(rezerwacjaModel);
        }

        // GET: Rezerwacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacjaModel = await _context.Rezerwacja.FindAsync(id);
            if (rezerwacjaModel == null)
            {
                return NotFound();
            }
            return View(rezerwacjaModel);
        }

        // POST: Rezerwacja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezerwacjaID,KomputerID,UzytkownikID,DataRozpoczecia,DataZakonczenia,DataPrzedluzona")] RezerwacjaModel rezerwacjaModel)
        {
            if (id != rezerwacjaModel.RezerwacjaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacjaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaModelExists(rezerwacjaModel.RezerwacjaID))
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
            return View(rezerwacjaModel);
        }

        // GET: Rezerwacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacjaModel = await _context.Rezerwacja
                .FirstOrDefaultAsync(m => m.RezerwacjaID == id);
            if (rezerwacjaModel == null)
            {
                return NotFound();
            }

            return View(rezerwacjaModel);
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacjaModel = await _context.Rezerwacja.FindAsync(id);
            _context.Rezerwacja.Remove(rezerwacjaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaModelExists(int id)
        {
            return _context.Rezerwacja.Any(e => e.RezerwacjaID == id);
        }

        //public async Task<IActionResult> CreateKomputer(int id)
        //{           
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

            
        //}
    }
}
