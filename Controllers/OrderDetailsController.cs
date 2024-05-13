using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess;
using PizzaPlaceAPI.DataAccess.Models;

namespace PizzaPlaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly PizzaPlaceDb dbContext;

        public OrderDetailsController(PizzaPlaceDb db)
        {
            dbContext = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetails>>> GetAllOrderDetails()
        {
            var orderDetails = await dbContext.OrderDetails.ToListAsync();

            return Ok(orderDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<OrderDetails>>> GetOrderDetail(int id)
        {
            var orderDetail = await dbContext.OrderDetails.FindAsync(id);

            if (orderDetail is null)
            {
                return NotFound("Order Detail not found.");
            }

            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderDetails>>> PostOrderDetails(OrderDetails orderDetail)
        {
            dbContext.OrderDetails.Add(orderDetail);
            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.OrderDetails.ToListAsync());
        }
    }
}
