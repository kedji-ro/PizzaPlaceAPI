using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess;
using PizzaPlaceAPI.DataAccess.Models;

namespace PizzaPlaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaTypesController : ControllerBase
    {
        private readonly PizzaPlaceDb dbContext;

        public PizzaTypesController(PizzaPlaceDb db)
        {
            dbContext = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaTypes>>> GetAllPizzaTypes()
        {
            var pizzaTypes = await dbContext.PizzaTypes.ToListAsync();

            return Ok(pizzaTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PizzaTypes>>> GetPizzaType(int id)
        {
            var pizzaType = await dbContext.PizzaTypes.FindAsync(id);

            if (pizzaType is null)
            {
                return NotFound("Pizza Type not found.");
            }

            return Ok(pizzaType);
        }

        [HttpPost]
        public async Task<ActionResult<List<PizzaTypes>>> PostPizzaType(PizzaTypes pizzaType)
        {
            dbContext.PizzaTypes.Add(pizzaType);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.PizzaTypes.ToListAsync());
        }
    }
}
