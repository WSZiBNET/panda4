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
    public class KomputerController : Controller
    {
        private readonly KomputerContext _context;

        public KomputerController(KomputerContext context)
        {
            _context = context;
        }

        // GET: Komputer
        public async Task<IActionResult> Index(string searchString)
        {
            
            ViewData["CurrentFilter"] = searchString;
            var komputerModel = from k in _context.KomputerModel
                                select k;
            if (!String.IsNullOrEmpty(searchString))
            {
                komputerModel = komputerModel.Where(k => k.Model.Contains(searchString)
                                       || k.Producent.Contains(searchString));
            }




        
           return View(await komputerModel.AsNoTracking().ToListAsync());
        }


        // GET: Ocena
        public async Task<IActionResult> IndexRanking()
        {


            var Komputery = await _context.KomputerModel.ToListAsync();
            foreach (var item in Komputery)
            {
                double sredniaOcena = 0;
                int suma = 0;
                int ilosc = 0;
                foreach (var ocena in _context.Ocena)
                {
                    if (ocena.KomputerID == item.KomputerID)
                    {
                        suma += ocena.Ocena;
                        ilosc++;

                        sredniaOcena = suma / ilosc;
                    }

                }
                item.sredniaOcena = sredniaOcena;
            }
            return View(Komputery);

         
        }



        // GET: Komputer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komputerModel = await _context.KomputerModel
                .FirstOrDefaultAsync(m => m.KomputerID == id);
            if (komputerModel == null)
            {
                return NotFound();
            }

            return View(komputerModel);
        }

        // GET: Komputer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Komputer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KomputerID,Model,Producent,Cena,DataProdukcji,KartaGraficzna,Procesor,PlytaGlowna")] KomputerModel komputerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komputerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komputerModel);
        }

        // GET: Komputer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           

            var komputerModel = await _context.KomputerModel.FindAsync(id);
            if (komputerModel == null)
            {
                return NotFound();
            }
            return View(komputerModel);
        }


        // POST: Komputer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KomputerID,Model,Producent,Cena,DataProdukcji,KartaGraficzna,Procesor,PlytaGlowna")] KomputerModel komputerModel)
        {
            if (id != komputerModel.KomputerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komputerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomputerModelExists(komputerModel.KomputerID))
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
            return View(komputerModel);
        }

        // GET: Komputer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var komputerModel = await _context.KomputerModel
                .FirstOrDefaultAsync(m => m.KomputerID == id);
            if (komputerModel == null)
            {
                return NotFound();
            }

            return View(komputerModel);
        }

        // POST: Komputer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komputerModel = await _context.KomputerModel.FindAsync(id);
            _context.KomputerModel.Remove(komputerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomputerModelExists(int id)
        {
            return _context.KomputerModel.Any(e => e.KomputerID == id);
        }
    }
}
