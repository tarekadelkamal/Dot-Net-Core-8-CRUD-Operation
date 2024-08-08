using GameZone.Services.Interface;
using GameZone.ViewModels;
using GameZone.Models;
using GameZone.Interfaces;
using GameZone.Repository;

namespace GameZone.Services.Services
{
    public class GameService : IGamesService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _Gameimage;
        private readonly IGame _GameRepo;
        public GameService(IWebHostEnvironment webHostEnvironment, IGame GameRepo)
        {
            _environment = webHostEnvironment;
            _Gameimage = $"{_environment.WebRootPath}/assets/images/games";
            _GameRepo = GameRepo;
        }
        public async Task Create(CreateGameVM model)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_Gameimage, CoverName);
            using var stream = File.Create(path);
            await  model.Cover.CopyToAsync(stream);
            stream.Dispose();

            var ListDevices = model.SelectedDevices.Select(d => new DeviceGame { DeviceId = d }).ToList();
            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = CoverName,
                Devices = ListDevices
            };

            await  _GameRepo.AddGameAsync(game);

        }

       /* public IEnumerable<Game> GetAll()
        {
            return _GameRepo.GetAllGames();
        }*/
    }
}
