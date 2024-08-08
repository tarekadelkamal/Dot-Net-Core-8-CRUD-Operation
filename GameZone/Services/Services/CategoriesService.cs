using GameZone.Interfaces;
using GameZone.Services.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        ICategories Categories;
        public CategoriesService(ICategories _CategoriesRep)
        {
            Categories = _CategoriesRep;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return Categories.GetAll().Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
               .OrderBy(x => x.Text).ToList();
        }
    }
}
