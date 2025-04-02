using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HistoriqueAlertesController : Controller
    {
        private readonly WebAppContext _context;

        public HistoriqueAlertesController(WebAppContext context)
        {
            _context = context;
        }

        // GET: HistoriqueAlertes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alerte.ToListAsync());
        }

        // GET: HistoriqueAlertes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _context.Alerte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alerte == null)
            {
                return NotFound();
            }

            return View(alerte);
        }

        // GET: HistoriqueAlertes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoriqueAlertes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Titre,Type,Description,Lieu,NiveauDanger,DateCreation,UtilisateurId")] Alerte alerte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alerte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alerte);
        }

        // GET: HistoriqueAlertes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _context.Alerte.FindAsync(id);
            if (alerte == null)
            {
                return NotFound();
            }
            return View(alerte);
        }

        // POST: HistoriqueAlertes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titre,Type,Description,Lieu,NiveauDanger,DateCreation,UtilisateurId")] Alerte alerte)
        {
            if (id != alerte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alerte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlerteExists(alerte.Id))
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
            return View(alerte);
        }

        // GET: HistoriqueAlertes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _context.Alerte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alerte == null)
            {
                return NotFound();
            }

            return View(alerte);
        }

        // POST: HistoriqueAlertes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alerte = await _context.Alerte.FindAsync(id);
            if (alerte != null)
            {
                _context.Alerte.Remove(alerte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlerteExists(int id)
        {
            return _context.Alerte.Any(e => e.Id == id);
        }
    }
}
