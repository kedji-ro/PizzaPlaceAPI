namespace PizzaPlaceAPI.DataAccess.Models
{
    public class PizzaTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Ingredients { get; set; }
    }
}
