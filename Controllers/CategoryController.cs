using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess;
using PizzaPlaceAPI.DataAccess.Models;

namespace PizzaPlaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly PizzaPlaceDb dbContext;

        public CategoryController(PizzaPlaceDb db)
        {
            dbContext = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await dbContext.Categories.ToListAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Category>>> GetCategory(int id)
        {
            var category = await dbContext.Categories.FindAsync(id);

            if (category is null)
            {
                return NotFound("Category not found.");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> PostCategory(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Categories.ToListAsync());
        }
    }
}
