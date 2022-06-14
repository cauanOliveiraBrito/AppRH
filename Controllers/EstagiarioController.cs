using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using APPRH.Models;

namespace APPRH.Controllers
{
    public class EstagiarioController : Controller
    {
         private readonly AplicationDBContext _context;

        public EstagiarioController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: Estagiario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estagiario.ToListAsync());
        }

        // GET: Estagiario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Estagiario = await _context.Estagiario
                .FirstOrDefaultAsync(m => m.estagiarioid == id);
            if (Estagiario == null)
            {
                return NotFound();
            }

            return View(Estagiario);
        }

        // GET: Estagiario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estagiario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("estagiarioid,nome,idade,cpf,cargo,matricula")] Estagiario estagiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estagiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estagiario);
        }

        // GET: Estagiario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estagiario = await _context.Estagiario.FindAsync(id);
            if (estagiario == null)
            {
                return NotFound();
            }
            return View(estagiario);
        }

        // POST: Estagiario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("estagiarioid,nome,idade,cpf,cargo,matricula")] Estagiario estagiario)
        {
            if (id != estagiario.estagiarioid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estagiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstagiarioExists(estagiario.estagiarioid))
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
            return View(estagiario);
        }

        // GET: Estagiario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estagiario = await _context.Estagiario
                .FirstOrDefaultAsync(m => m.estagiarioid == id);
            if (estagiario == null)
            {
                return NotFound();
            }

            return View(estagiario);
        }

        // POST: Estagiario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estagiario = await _context.Estagiario.FindAsync(id);
            _context.Estagiario.Remove(estagiario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstagiarioExists(int id)
        {
            return _context.Estagiario.Any(e => e.estagiarioid == id);
        }
    }
}