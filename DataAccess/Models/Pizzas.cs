namespace PizzaPlaceAPI.DataAccess.Models
{
    public class Pizzas
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
