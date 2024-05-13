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

app.MapGet("/categories", async (PizzaPlaceDb db) =>
    await db.Categories.ToListAsync());

app.MapGet("/categories/{id}", async (int id, PizzaPlaceDb db) =>
    await db.Categories.FindAsync(id)
        is Category category
            ? Results.Ok(category)
            : Results.NotFound());

app.MapGet("/sizes", async (PizzaPlaceDb db) =>
    await db.Sizes.ToListAsync());

app.MapGet("/sizes/{id}", async (int id, PizzaPlaceDb db) =>
    await db.Sizes.FindAsync(id)
        is Size size
            ? Results.Ok(size)
            : Results.NotFound());

#endregion

# region POST methods

app.MapPost("/order", async (Orders order, PizzaPlaceDb db) =>
{
    db.Orders.Add(order);
    await db.SaveChangesAsync();

    return Results.Created($"/order/{order.Id}", order);
});

app.MapPost("/order_details", async (OrderDetails orderDetails, PizzaPlaceDb db) =>
{
    db.OrderDetails.Add(orderDetails);
    await db.SaveChangesAsync();

    return Results.Created($"/order_details/{orderDetails.Id}", orderDetails);
});

app.MapPost("/pizza", async (Pizzas pizza, PizzaPlaceDb db) =>
{
    db.Pizzas.Add(pizza);
    await db.SaveChangesAsync();

    return Results.Created($"/pizza/{pizza.Id}", pizza);
});

app.MapPost("/pizza_types", async (PizzaTypes pizzaType, PizzaPlaceDb db) =>
{
    db.PizzaTypes.Add(pizzaType);
    await db.SaveChangesAsync();

    return Results.Created($"/pizza_types/{pizzaType.Id}", pizzaType);
});

app.MapPost("/category", async (Category category, PizzaPlaceDb db) =>
{
    db.Categories.Add(category);
    await db.SaveChangesAsync();

    return Results.Created($"/category/{category.Id}", category);
});

app.MapPost("/size", async (Size size, PizzaPlaceDb db) =>
{
    db.Sizes.Add(size);
    await db.SaveChangesAsync();

    return Results.Created($"/size/{size.Id}", size);
});

# endregion

# region PUT methods

app.MapPut("/pizzas/{id}", async (int id, Pizzas inputTodo, PizzaPlaceDb db) =>
{
    var pizza = await db.Pizzas.FindAsync(id);

    if (pizza is null) return Results.NotFound();

    pizza.TypeId = inputTodo.TypeId;
    pizza.SizeId = inputTodo.SizeId;
    pizza.Price = inputTodo.Price;
    
    await db.SaveChangesAsync();

    return Results.NoContent();
});

# endregion

# region END methods

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

# endregion

app.Run();
