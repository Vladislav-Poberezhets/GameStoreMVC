using GameStore.Interfaces;
using GameStore.Models;
using GameStore.Models.Pages;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace GameStore.Repository
{
    public class GameRepository : IGame
    {
        private ApplicationContext _context;

        public GameRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddGame(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games.Include(e => e.Category);
        }
        public Game? GetGame(int id)
        {
            return _context.Games.Include(e => e.Category).FirstOrDefault(e => e.GameId == id); 
        }

        public void EditGame(Game game)
        {
            Game game2 = _context.Games.Find(game.GameId);
            game2.Name = game.Name;
            game2.Description = game.Description;
            game2.Price = game.Price;
            game2.CategoryId = game.CategoryId;
            _context.SaveChanges();
        }

        public void DeleteGame(Game game) 
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public PagedList<Game> GetGames(QueryOptions options, int category = 0)
        {
            IQueryable<Game> games = _context.Games.Include(e => e.Category);
            if (category != 0)
            {
                games = games.Where(e => e.CategoryId == category);
            }
            return new PagedList<Game>(games, options);
        }
    }
}
