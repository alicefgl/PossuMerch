using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PossuMerch.Data;

namespace PossuMerch.Controllers
{
    public class UsersController : Controller
    {
        private readonly dbContext _context;

        public UsersController(dbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utenti.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utenti
                .FirstOrDefaultAsync(m => m.Email == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Users/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Nome,Cognome,DataDiNascita,Password,NewsLetter")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("/Home/Index.cshtml");
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utenti.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            return View(utente);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Nome,Cognome,DataDiNascita,Password,NewsLetter")] Utente utente)
        {
            if (id != utente.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Email))
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
            return View(utente);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utenti
                .FirstOrDefaultAsync(m => m.Email == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var utente = await _context.Utenti.FindAsync(id);
            if (utente != null)
            {
                _context.Utenti.Remove(utente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtenteExists(string id)
        {
            return _context.Utenti.Any(e => e.Email == id);
        }
    }
}
