using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGame _games;

        public HomeController(IGame games)
        {
            _games = games;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_games.GetAllGames());
        }
        [HttpPost]
        public IActionResult AddProduct(Game game)
        {
            _games.AddGame(game);
            return RedirectToAction(nameof(Index));
        }
    }
}