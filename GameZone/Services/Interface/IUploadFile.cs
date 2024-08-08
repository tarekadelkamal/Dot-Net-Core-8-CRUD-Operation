using System.Diagnostics.Eventing.Reader;
using GameZone.ViewModels;
namespace GameZone.Services.Interface
{
    public interface IUploadFile
    {
        public void UploadFile(EditGameFormVM fileName);
    }
}
