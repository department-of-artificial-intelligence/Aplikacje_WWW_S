namespace AWWW_lab3_gr1.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = null!;

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
