using GameZone.Interfaces;

namespace GameZone.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Cover { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        public ICollection<DeviceGame> Devices { get; set; }

    }
}
