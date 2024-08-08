using GameZone.Attribute;
using GameZone.Configurations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class EditGameFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = new List<int>();
        public IEnumerable<SelectListItem> Devices { get; set; } = new List<SelectListItem>();
        public string Description { get; set; } = string.Empty;
        [AllowedExtension(FileSettings.allowedExtension), MaxSizeImage(FileSettings.max_size)]
        public IFormFile? Cover { get; set; } = default!;
        public string? CurrentCover { get; set; }

    }
}
