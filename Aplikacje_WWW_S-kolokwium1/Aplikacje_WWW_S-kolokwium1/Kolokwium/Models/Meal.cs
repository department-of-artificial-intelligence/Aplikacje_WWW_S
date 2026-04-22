namespace Kolokwium.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsVegetarian { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
