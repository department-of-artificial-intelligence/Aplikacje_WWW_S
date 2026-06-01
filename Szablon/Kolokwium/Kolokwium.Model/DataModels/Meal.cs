namespace Kolokwium.Model.DataModels
{
    public class Meal
    {
        public int Id {get; set; }

        public string? Type {get; set;}
        public bool IsVegetarian {get; set;}
        public string Description {get; set; } = string.Empty;

        public decimal Price {get; set; }

        public virtual ICollection<Order> Orders {get; set; } = new List<Order>();
    }
}