using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSAEP.Data;
using SchoolSAEP.Models;

namespace SchoolSAEP.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AtividadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Atividade
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Atividade.Include(a => a.Turma);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Atividade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atividade == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AtividadeId == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // GET: Atividade/Create
        public IActionResult Create()
        {
            ViewData["TurmaId"] = new SelectList(_context.Turma, "TurmaId", "Nome");
            return View();
        }

        // POST: Atividade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtividadeId,Nome,TurmaId")] Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurmaId"] = new SelectList(_context.Turma, "TurmaId", "Nome", atividade.TurmaId);
            return View(atividade);
        }

        // GET: Atividade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atividade == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }
            ViewData["TurmaId"] = new SelectList(_context.Turma, "TurmaId", "Nome", atividade.TurmaId);
            return View(atividade);
        }

        // POST: Atividade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtividadeId,Nome,TurmaId")] Atividade atividade)
        {
            if (id != atividade.AtividadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeExists(atividade.AtividadeId))
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
            ViewData["TurmaId"] = new SelectList(_context.Turma, "TurmaId", "Nome", atividade.TurmaId);
            return View(atividade);
        }

        // GET: Atividade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atividade == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AtividadeId == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // POST: Atividade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atividade == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Atividade'  is null.");
            }
            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade != null)
            {
                _context.Atividade.Remove(atividade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeExists(int id)
        {
          return (_context.Atividade?.Any(e => e.AtividadeId == id)).GetValueOrDefault();
        }
    }
}
