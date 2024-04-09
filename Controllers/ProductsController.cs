using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PossuMerch.Data;

namespace PossuMerch.Controllers
{
    public class ProductsController : Controller
    {
        static List<Prodotto> Carrello { get; set; } = new();
        private readonly dbContext _context;
        private readonly SignInManager<Utente> _signInManager;

        public ProductsController(dbContext context, SignInManager<Utente> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(Carrello);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .FirstOrDefaultAsync(m => m._NomeP == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("_NomeP,Quantita,TipoP,Prezzo")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodotto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("_NomeP,Quantita,TipoP,Prezzo")] Prodotto prodotto)
        {
            if (id != prodotto._NomeP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodotto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottoExists(prodotto._NomeP))
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
            return View(prodotto);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .FirstOrDefaultAsync(m => m._NomeP == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto != null)
            {
                _context.Prodotti.Remove(prodotto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottoExists(string id)
        {
            return _context.Prodotti.Any(e => e._NomeP == id);
        }
        public async Task<IActionResult> Purchase_Bassi()
        {
            return View(await _context.Prodotti.ToListAsync());
        }
        public async Task<IActionResult> Purchase_Chitarre()
        {
            return View(await _context.Prodotti.ToListAsync());
        }
        
        public async Task<IActionResult> Cart()
        {
            var c1 = from c in _context.Carrello
                     where c.UserName == _signInManager.UserManager.GetUserName(User)
                     select c;

            return View(await c1.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Cart([Bind("_NomeP, TipoP, Prezzo, UserName, Quantita")] RigaCarrello r)
        {
            if (ModelState.IsValid)
            {
                await _context.Carrello.AddAsync(r);
                await _context.SaveChangesAsync();
            }
            return View(await _context.Carrello.ToListAsync());
        }
    }
}
