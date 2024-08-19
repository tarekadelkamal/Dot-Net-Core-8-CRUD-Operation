using System.Diagnostics.Eventing.Reader;
using GameZone.ViewModels;
namespace GameZone.Services.Interface
{
    public interface IUploadFile
    {
        public  Task<string> UploadFile(IFormFile cover);
    }
}
