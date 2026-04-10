namespace AWWW_lab4_gr1.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
