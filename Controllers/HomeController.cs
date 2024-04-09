using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PossuMerch.Models;
using PossuMerch.Data;

namespace PossuMerch.Controllers;

public class HomeController : Controller
{   private readonly ILogger<HomeController> _logger;
    private List<Utente> Utenti;
    private List<Prodotto> Prodotti;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        Utenti = new List<Utente>();
        Prodotti = new List<Prodotto>();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Conferma(Utente p)
    {
        Utenti.Add(p);
        return View(Utenti);
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Purchase_Bassi()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cart(Prodotto prod)
    {
        Prodotti.Add(prod);
        return View(Prodotti);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult ChiSiamo()
    {
        return View();
    }
    public IActionResult LegalNotices()
    {
        return View();
    }

    /*private List<Cart> GetCartItemsFromDatabase()
    {
        var userId = User.idUtente;
        var cartItems = dbContext.Cart
            .Where(c => c.UserId == userId)
            .Include(c => c.Product)
            .ToList();

        return cartItems;
    }*/
}
