using GameStore.Models;

namespace GameStore.Interfaces
{
    public interface IGame
    {
        IEnumerable<Game> GetAllGames();
        void AddGame(Game game);
    }
}
