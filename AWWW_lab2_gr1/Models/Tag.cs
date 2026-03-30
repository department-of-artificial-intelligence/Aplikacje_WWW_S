namespace AWWW_lab2_gr1.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}