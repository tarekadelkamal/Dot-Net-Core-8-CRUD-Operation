using GameZone.Interfaces;
using GameZone.Models;
using GameZone.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        IGame gamesrepo;
        
        public HomeController(IGame _gamesrepo)
        {
            gamesrepo = _gamesrepo;
        }

        public IActionResult Index()
        {
            var Games = gamesrepo.GetAllGames();
            return View(Games);
        }

 
    }
}