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
            _Gameimage = $"{_environment.WebRootPath}/assets/images/games";
        }
        public void UploadFile(EditGameFormVM fileName)
        {
           /* var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(fileName.FileName)}";
            var path = Path.Combine(_Gameimage, CoverName);
            using var stream = File.Create(path);
            fileName.CopyTo(stream);
            stream.Dispose();*/
        }
    }
}
