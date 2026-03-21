namespace AWWW_lab2_gr1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } //1 kategoria, wiele produktow
    }
}
