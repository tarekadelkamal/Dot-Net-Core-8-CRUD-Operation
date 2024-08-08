using GameZone.Interfaces;
using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Repository
{
    public class DevicesRep : IDevices
    {
        private ApplicationDBContext contect;

        public DevicesRep(ApplicationDBContext _context)
        {
            contect = _context;
        }
        public List<Device> GetAll()
        {
            return contect.Devices.AsNoTracking().ToList();
        }
    }
}
