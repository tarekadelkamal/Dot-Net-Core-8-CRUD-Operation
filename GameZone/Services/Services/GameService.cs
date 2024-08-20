using GameZone.Services.Interface;
using GameZone.ViewModels;
using GameZone.Models;
using GameZone.Interfaces;
using GameZone.Repository;
using GameZone.Services.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using GameZone.Configurations;

namespace GameZone.Services.Services
{
    public class GameService : IGamesService
    {
        private readonly IGame _GameRepo;
        private IUploadFile _UploadFile;
        private readonly IWebHostEnvironment _environment;
        private readonly string _Gameimage;
        public GameService(IWebHostEnvironment webHostEnvironment, IGame GameRepo, IUploadFile UploadFile)
        {
            _GameRepo = GameRepo;
            _UploadFile = UploadFile;
            _environment = webHostEnvironment;
            _Gameimage = $"{_environment.WebRootPath}/assets/images/games";
        }
        public async Task Create(CreateGameVM model)
        {
            var fileName = await _UploadFile.UploadFile(model.Cover);
            var ListDevices = model.SelectedDevices.Select(d => new DeviceGame { DeviceId = d }).ToList();
            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = fileName.ToString(),
                Devices = ListDevices
            };
            await  _GameRepo.AddGameAsync(game);
        }

        public async Task Update(EditGameFormVM model)
        {
            Game game = _GameRepo.FindGame(model.Id);
            game.Name = model.Name;
            game.Description = model.Description;
            game.Devices = model.SelectedDevices.Select(d => new DeviceGame { DeviceId = d }).ToList();
            game.CategoryId = model.CategoryId;

            if (model.Cover is not null)
            {
                var OldCover = Path.Combine(_Gameimage, model.CurrentCover);
                File.Delete(OldCover);
                game.Cover = await _UploadFile.UploadFile(model.Cover);
            }
            _GameRepo.Update(game);
 
        }
    }
}
