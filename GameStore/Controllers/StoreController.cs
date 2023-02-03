using GameStore.Interfaces;
using GameStore.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGame _games;
        private readonly ICategory _categories;

        public StoreController(IGame games, ICategory categories)
        {
            _games = games;
            _categories = categories;
        }
        public IActionResult Index([FromQuery(Name = "options")] QueryOptions gameOptions, QueryOptions catOptions, int category)
        {
            ViewBag.Categories = _categories.GetCategories(catOptions);
            ViewBag.SelectedCategory = category;
            return View(_games.GetGames(gameOptions, category));
        }
    }
}
