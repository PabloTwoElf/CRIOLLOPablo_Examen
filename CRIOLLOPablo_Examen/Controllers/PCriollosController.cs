using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRIOLLOPablo_Examen.Data;
using CRIOLLOPablo_Examen.Models;

namespace CRIOLLOPablo_Examen.Controllers
{
    public class PCriollosController : Controller
    {
        private readonly CRIOLLOPablo_ExamenContext _context;

        public PCriollosController(CRIOLLOPablo_ExamenContext context)
        {
            _context = context;
        }

        // GET: PCriollos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PCriollo.ToListAsync());
        }

        // GET: PCriollos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCriollo = await _context.PCriollo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pCriollo == null)
            {
                return NotFound();
            }

            return View(pCriollo);
        }

        // GET: PCriollos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PCriollos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Altura,Discapacidad,Fecha")] PCriollo pCriollo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pCriollo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pCriollo);
        }

        // GET: PCriollos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCriollo = await _context.PCriollo.FindAsync(id);
            if (pCriollo == null)
            {
                return NotFound();
            }
            return View(pCriollo);
        }

        // POST: PCriollos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Altura,Discapacidad,Fecha")] PCriollo pCriollo)
        {
            if (id != pCriollo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pCriollo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PCriolloExists(pCriollo.Id))
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
            return View(pCriollo);
        }

        // GET: PCriollos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCriollo = await _context.PCriollo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pCriollo == null)
            {
                return NotFound();
            }

            return View(pCriollo);
        }

        // POST: PCriollos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pCriollo = await _context.PCriollo.FindAsync(id);
            if (pCriollo != null)
            {
                _context.PCriollo.Remove(pCriollo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PCriolloExists(int id)
        {
            return _context.PCriollo.Any(e => e.Id == id);
        }
    }
}
