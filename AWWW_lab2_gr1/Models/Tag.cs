namespace AWWW_lab2_gr1.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}