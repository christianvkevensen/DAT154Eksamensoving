#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleaningService.Models;

namespace CleaningService.Controllers
{
    public class OppgavesController : Controller
    {
        private readonly Oblig4Context _context;

        
        public OppgavesController(Oblig4Context context)
        {
            _context = context;
        }

        // GET: Oppgaves
        public async Task<IActionResult> Index(String? task)
        {
            if(string.IsNullOrEmpty(task))
            {
                return View(_context.Oppgaver.ToList());
            }
            ViewData["task"] = task;
            var oppgaver = _context.Oppgaver.Where(o => o.Work.Equals(task)).ToList();
            return View(oppgaver);
        }

        // GET: Oppgaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oppgave = await _context.Oppgaver
                .FirstOrDefaultAsync(m => m.OppgaveId == id);
            if (oppgave == null)
            {
                return NotFound();
            }

            return View(oppgave);
        }

        // GET: Oppgaves/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult chooseWork(string task)
        {
            //List<Oppgave> oppgaver =  _context.Oppgaver.Where(o => o.Work.Equals(task)).ToList();
            return View(task);
        }

        // POST: Oppgaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OppgaveId,Notes,Work,Status")] Oppgave oppgave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oppgave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oppgave);
        }

        // GET: Oppgaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oppgave = await _context.Oppgaver.FindAsync(id);
            if (oppgave == null)
            {
                return NotFound();
            }
            return View(oppgave);
        }

        // POST: Oppgaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OppgaveId,Notes,Work,Status")] Oppgave oppgave)
        {
            if (id != oppgave.OppgaveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oppgave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OppgaveExists(oppgave.OppgaveId))
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
            return View(oppgave);
        }

        // GET: Oppgaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oppgave = await _context.Oppgaver
                .FirstOrDefaultAsync(m => m.OppgaveId == id);
            if (oppgave == null)
            {
                return NotFound();
            }

            return View(oppgave);
        }

        // POST: Oppgaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oppgave = await _context.Oppgaver.FindAsync(id);
            _context.Oppgaver.Remove(oppgave);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OppgaveExists(int id)
        {
            return _context.Oppgaver.Any(e => e.OppgaveId == id);
        }
    }
}
