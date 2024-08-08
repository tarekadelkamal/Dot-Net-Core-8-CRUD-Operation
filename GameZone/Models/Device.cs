using Microsoft.EntityFrameworkCore;

namespace GameZone.Models
{
     
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<DeviceGame> Games { get; set; }
        
    }
}
