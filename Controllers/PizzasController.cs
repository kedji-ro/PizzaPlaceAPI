using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess;
using PizzaPlaceAPI.DataAccess.Models;

namespace PizzaPlaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaPlaceDb dbContext;

        public PizzasController(PizzaPlaceDb db)
        {
            dbContext = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pizzas>>> GetAllPizzas()
        {
            var pizzas = await dbContext.Pizzas.ToListAsync();

            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pizzas>>> GetPizza(int id)
        {
            var pizza = await dbContext.Pizzas.FindAsync(id);

            if (pizza is null)
            {
                return NotFound("Pizza not found.");
            }

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pizzas>>> PostPizza(Pizzas pizza)
        {
            dbContext.Pizzas.Add(pizza);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Pizzas.ToListAsync());
        }
    }
}
