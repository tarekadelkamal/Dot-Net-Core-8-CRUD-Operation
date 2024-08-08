using GameZone.Interfaces;
using GameZone.Models;
using GameZone.Repository;
using GameZone.Services.Interface;
using GameZone.Services.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
       
        ICategoriesService categoriesService;
        IDevicesService DevicesService;
        IDevices Devices;
        IGamesService gamesService;
        CreateGameVM DefualtData;
        IGame gameRepo;
        public GamesController(IDevices _Devices,
            ICategoriesService _categoryservice,
            IDevicesService _devicesService,
            IGamesService _gameservice,
            IGame _game
            )
        {
            categoriesService = _categoryservice;
            DevicesService = _devicesService;
            Devices = _Devices;
            gamesService = _gameservice;
            gameRepo = _game;
            DefualtData = new CreateGameVM()
            {
                Categories = categoriesService.GetSelectList(),
                Devices = DevicesService.GetAllDevicesList(),
            };
        }
        public IActionResult Index()
        {
            var Games = gameRepo.GetAllGames();
            return View(Games);
        }

        [HttpGet]
        public IActionResult Create()
        {
             return View(DefualtData);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameVM model)
        {
            if (ModelState.IsValid)
            {
                await gamesService.Create(model);
                return RedirectToAction("Index");
            }
            return View("Create", DefualtData);
        }
        
        public IActionResult Details(int id)
        {
            var game = gameRepo.GetDetsils(id);
            if(game is null)
            {
                return NotFound();
            }
            return View( game); 
        }

        public IActionResult Edit(int id)
        {
            var game = gameRepo.GetDetsils(id);
            if (game is null)
                return NotFound();

            EditGameFormVM editGame = new EditGameFormVM()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                Categories = categoriesService.GetSelectList(),
                Devices = DevicesService.GetAllDevicesList(),
                SelectedDevices = game.Devices.Select(x => x.DeviceId).ToList(),
                CurrentCover = game.Cover
            };
            return View("Edit" ,editGame);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditGameFormVM model)
        {

            if (ModelState.IsValid)
            {
                var  hasNewCover = model.Cover ;
                var oldCover = model.CurrentCover;

                if (hasNewCover is not null)
                {
                    model.Cover = model.Cover;
                }
                else
                {
                    model.Cover = null;
                }
                
                var result = gameRepo.Update(model);
               /* if(result.Cover is not null )
                {
                    UploadFileService.UploadFile(model.Cover);
                }*/
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }
    }
}
