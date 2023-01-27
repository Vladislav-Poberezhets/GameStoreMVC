using GameStore.Interfaces;
using GameStore.Models;

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
            return _context.Games;
        }
    }
}
