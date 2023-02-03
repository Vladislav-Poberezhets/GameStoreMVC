using GameStore.Models;
using GameStore.Models.Pages;

namespace GameStore.Interfaces
{
    public interface IGame
    {
        PagedList<Game> GetGames(QueryOptions options, int category = 0);
        IEnumerable<Game> GetAllGames();
        Game GetGame(int id);
        void AddGame(Game game);
        void EditGame(Game game);

        void DeleteGame(Game game);
    }
}
