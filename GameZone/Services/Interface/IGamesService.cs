using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Services.Interface
{
    public interface IGamesService
    {
        public Task Create(CreateGameVM model);

       // public IEnumerable<Game> GetAll();
    }
}
