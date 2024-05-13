using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess;
using PizzaPlaceAPI.DataAccess.Models;

namespace PizzaPlaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly PizzaPlaceDb dbContext;

        public SizeController(PizzaPlaceDb db)
        {
            dbContext = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Size>>> GetAllSizes()
        {
            var sizes = await dbContext.Sizes.ToListAsync();

            return Ok(sizes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Size>>> GetSize(int id)
        {
            var size = await dbContext.Sizes.FindAsync(id);

            if (size is null)
            {
                return NotFound("Size not found.");
            }

            return Ok(size);
        }

        [HttpPost]
        public async Task<ActionResult<List<Size>>> PostSize(Size size)
        {
            dbContext.Sizes.Add(size);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Sizes.ToListAsync());
        }
    }
}
