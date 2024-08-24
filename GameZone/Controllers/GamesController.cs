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
        public async Task<IActionResult> Edit(EditGameFormVM model)
        {

            if (ModelState.IsValid)
            {
               await gamesService.Update(model);
                return RedirectToAction("Index");
            }
            return View("Edit", model);
        }

        public IActionResult Delete(int id)
        {
              var res = gameRepo.Delete(id);
            if (res is null)
                return NotFound();
            return RedirectToAction("index");
        }
    }
}
