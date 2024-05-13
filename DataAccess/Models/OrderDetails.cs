namespace PizzaPlaceAPI.DataAccess.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int Qty { get; set; }
    }
}
