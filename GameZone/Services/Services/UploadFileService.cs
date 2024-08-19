using GameZone.Configurations;
using GameZone.Services.Interface;
using GameZone.ViewModels;
namespace GameZone.Services.Services
{
    public class UploadFileService : IUploadFile
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _Gameimage;
        public UploadFileService(IWebHostEnvironment webHostEnvironment)
        {
            _environment = webHostEnvironment;
            _Gameimage = $"{_environment.WebRootPath}{FileSettings.ImagePath}";
        }
        public async Task<string> UploadFile(IFormFile cover)
        {
            string CoverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_Gameimage, CoverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            stream.Dispose();
            return CoverName;
        }
    }
}
