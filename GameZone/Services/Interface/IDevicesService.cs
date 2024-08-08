using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Interface
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetAllDevicesList();
    }
}
