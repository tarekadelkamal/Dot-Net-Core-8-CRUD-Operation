using GameZone.Interfaces;
using GameZone.Services.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Services
{
    public class DevicesService : IDevicesService
    {
        IDevices Devices;
        public DevicesService(IDevices _Devices)
        {
            Devices = _Devices;
        }
        public IEnumerable<SelectListItem> GetAllDevicesList()
        {
            return Devices.GetAll().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                 .OrderBy(x => x.Text)
                 .ToList();
        }
    }
}
