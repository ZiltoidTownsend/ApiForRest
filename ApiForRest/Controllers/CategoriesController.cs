using LibraryMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ApiForRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApplicationContext db;

        public CategoriesController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<CategoryData>>> Get()
        {
            var categoryes = await db.Categories.Include(c => c.Dishes).ToListAsync();
            //foreach (var cat in categoryes)
            //{
            //    foreach (var dish in cat.Dishes)
            //    {
            //        dish.Category = null;
            //    }
            //}
            return categoryes;
        }
    }
}
