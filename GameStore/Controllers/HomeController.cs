using GameStore.Interfaces;
using GameStore.Models;
using GameStore.Models.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGame _games;
        private readonly ICategory _categories;

        public HomeController(IGame games, ICategory categories)
        {
            _games = games;
            _categories = categories;
        }
        [HttpGet]
        public IActionResult Index(QueryOptions options)
        {
            return View(_games.GetGames(options));
        }
        [HttpGet]
        public IActionResult EditGame(int id)
        {
            ViewBag.Categories = _categories.GetAllCategories();
            return View(id == 0 ? new Game() : _games.GetGame(id));
        }
        [HttpPost]
        public IActionResult EditGame(Game game)
        {
            if (game.GameId == 0)
            {
                _games.AddGame(game);
            }
            else
            {
                _games.EditGame(game);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteGame(Game game)
        {
            _games.DeleteGame(game);
            return RedirectToAction(nameof(Index));
        }
    }
}