using Microsoft.EntityFrameworkCore;
using PizzaPlaceAPI.DataAccess;
using PizzaPlaceAPI.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PizzaPlaceDb>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

# region GET Methods

app.MapGet("/pizzas", async (PizzaPlaceDb db) =>
    await db.Pizzas.ToListAsync());

app.MapGet("/pizzas/{id}", async (int id, PizzaPlaceDb db) =>
    await db.Pizzas.FindAsync(id)
        is Pizzas pizza
            ? Results.Ok(pizza)
            : Results.NotFound());

app.MapGet("/pizza_types", async (PizzaPlaceDb db) =>
    await db.PizzaTypes.ToListAsync());

app.MapGet("/pizza_types/{id}", async (int id, PizzaPlaceDb db) =>
    await db.PizzaTypes.FindAsync(id)
        is PizzaTypes pizzaType
            ? Results.Ok(pizzaType)
            : Results.NotFound());

app.MapGet("/orders", async (PizzaPlaceDb db) =>
    await db.Orders.ToListAsync());

app.MapGet("/orders/{id}", async (int id, PizzaPlaceDb db) =>
    await db.Orders.FindAsync(id)
        is Orders order
            ? Results.Ok(order)
            : Results.NotFound());

app.MapGet("/order_details/{id}", async (int id, PizzaPlaceDb db) =>
    await db.OrderDetails.FindAsync(id)
        is OrderDetails orderDetail
            ? Results.Ok(orderDetail)
            : Results.NotFound());

#endregion

app.MapPut("/pizzas/{id}", async (int id, Pizzas inputTodo, PizzaPlaceDb db) =>
{
    var pizza = await db.Pizzas.FindAsync(id);

    if (pizza is null) return Results.NotFound();

    pizza.TypeId = inputTodo.TypeId;
    pizza.Size = inputTodo.Size;
    pizza.Price = inputTodo.Price;
    
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/pizzas/{id}", async (int id, PizzaPlaceDb db) =>
{
    if (await db.Pizzas.FindAsync(id) is Pizzas pizza)
    {
        db.Pizzas.Remove(pizza);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
