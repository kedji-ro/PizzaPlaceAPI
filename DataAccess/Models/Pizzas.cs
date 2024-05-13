namespace PizzaPlaceAPI.DataAccess.Models
{
    public class Pizzas
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int TypeId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
    }
}
