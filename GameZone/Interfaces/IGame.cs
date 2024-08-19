using GameZone.Models;
using GameZone.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace GameZone.Interfaces
{
    public interface IGame
    {
        public  Task AddGameAsync(Game game);
        public IEnumerable<Game> GetAllGames();
        public Game? GetDetsils(int detsId);
        public Game? Update(Game game);
        public Game? FindGame(int Id);
    }
}
