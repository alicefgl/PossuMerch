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
    public class CarrelloController : Controller
    {
        private readonly dbContext _context;

        public CarrelloController(dbContext context)
        {
            _context = context;
        }

        // GET: Carrello
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrello.ToListAsync());
        }

        // GET: Carrello/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rigaCarrello = await _context.Carrello
                .FirstOrDefaultAsync(m => m.IdRigaCarrello == id);
            if (rigaCarrello == null)
            {
                return NotFound();
            }

            return View(rigaCarrello);
        }

        // GET: Carrello/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrello/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRigaCarrello,_NomeP,TipoP,Prezzo,UserName,Quantita")] RigaCarrello rigaCarrello)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rigaCarrello);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rigaCarrello);
        }

        // GET: Carrello/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rigaCarrello = await _context.Carrello.FindAsync(id);
            if (rigaCarrello == null)
            {
                return NotFound();
            }
            return View(rigaCarrello);
        }

        // POST: Carrello/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("IdRigaCarrello,_NomeP,TipoP,Prezzo,UserName,Quantita")] RigaCarrello rigaCarrello)
        {
            if (id != rigaCarrello.IdRigaCarrello)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rigaCarrello);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RigaCarrelloExists(rigaCarrello.IdRigaCarrello))
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
            return View(rigaCarrello);
        }

        // GET: Carrello/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rigaCarrello = await _context.Carrello
                .FirstOrDefaultAsync(m => m.IdRigaCarrello == id);
            if (rigaCarrello == null)
            {
                return NotFound();
            }

            return View(rigaCarrello);
        }

        // POST: Carrello/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var rigaCarrello = await _context.Carrello.FindAsync(id);
            if (rigaCarrello != null)
            {
                _context.Carrello.Remove(rigaCarrello);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RigaCarrelloExists(int? id)
        {
            return _context.Carrello.Any(e => e.IdRigaCarrello == id);
        }
    }
}
