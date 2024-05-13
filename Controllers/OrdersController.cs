using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess;
using PizzaPlaceAPI.DataAccess.Models;

namespace PizzaPlaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaPlaceDb dbContext;

        public OrdersController(PizzaPlaceDb db)
        {
            dbContext = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Orders>>> GetAllOrders()
        {
            var orders = await dbContext.Orders.ToListAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Orders>>> GetOrder(int id)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if (order is null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<List<Orders>>> PostOrder(Orders order)
        {
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Orders.ToListAsync());
        }
    }
}
