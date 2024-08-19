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
            
           /* Game game = this.FindGame(model.Id);

            if (game is null)
                return null;

            game.Name = model.Name;
            game.Description = model.Description;
            game.Devices = model.SelectedDevices.Select(d => new DeviceGame { DeviceId = d }).ToList();
            game.CategoryId = model.CategoryId;

            if (model.Cover is not null)
            {
                game.Cover = model.Cover.ToString();
            }

            var effected_rows = _dbContext.SaveChanges();

            return  (effected_rows > 0) ?  game :  null;*/

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
