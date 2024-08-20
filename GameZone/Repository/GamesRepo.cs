using GameZone.Interfaces;
using GameZone.Models;
using GameZone.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Repository
{
    public class GamesRepo : IGame
    {
        private readonly ApplicationDBContext _dbContext;
        public GamesRepo(ApplicationDBContext context)
        {
            _dbContext  = context;
        }
        public async Task AddGameAsync(Game game)
        {
            await _dbContext.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _dbContext.Games
                .Include(x => x.Category)
                .Include(s => s.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }

        public Game? GetDetsils(int detsId)
        {
            return _dbContext.Games
                .Include(x => x.Category)
                .Include(s => s.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .SingleOrDefault(x => x.Id == detsId);
        }

        public Game? Update(Game game)
        {
            _dbContext.Games.Update(game);
            var effected_rows =  _dbContext.SaveChanges();
            return (effected_rows > 0) ? game : null;
        }

        public Game? FindGame(int Id)
        {
           return _dbContext.Games.Include(d => d.Devices)
                .SingleOrDefault(s => s.Id == Id);
        }
    }
}
