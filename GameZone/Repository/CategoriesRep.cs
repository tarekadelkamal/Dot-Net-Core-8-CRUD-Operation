using GameZone.Interfaces;
using GameZone.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Repository
{
    public class CategoriesRep : ICategories
    {
        private ApplicationDBContext context;

        public CategoriesRep(ApplicationDBContext _context)
        {
            context = _context;
        }
        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }
    }
}
