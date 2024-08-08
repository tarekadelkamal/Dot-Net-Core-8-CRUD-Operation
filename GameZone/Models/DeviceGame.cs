using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
     
    public class DeviceGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int DeviceId { get; set; }
        public Game Game { get; set; }
        public Device Device { get; set; }
    }
}
