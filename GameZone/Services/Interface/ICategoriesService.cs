using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Interface
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
