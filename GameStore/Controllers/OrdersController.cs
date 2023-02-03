using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IGame _games;
        private readonly IOrder _orders;

        public OrdersController(IGame games, IOrder orders)
        {
            _games = games;
            _orders = orders;
        }
        public IActionResult Index()
        {
            return View(_orders.GetAllOrders());
        }
        [HttpPost]
        public IActionResult AddOrUpdateOrder(Order order)
        {
            order.Lines = order.Lines.Where(e => e.Id > 0 || (e.Id == 0 && e.Quantity > 0)).ToArray();
            if (order.Id == 0)
            {
                _orders.AddOrder(order);
            }
            else
            {
                _orders.UpdateOrder(order);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditOrder(int id)
        {
            var games = _games.GetAllGames();
            Order order = id == 0 ? new Order() : _orders.GetOrder(id);
            IDictionary<int, OrderLine> lineMaps = order.Lines?.ToDictionary(e => e.GameId) ?? new Dictionary<int, OrderLine>();
            ViewBag.Lines = games.Select(e => lineMaps.ContainsKey(e.GameId) ? lineMaps[e.GameId] : new OrderLine
            {
                Game = e,
                GameId = e.GameId,
                Quantity = 0
            });
            return View(order);
        }
    }
}
