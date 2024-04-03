using System.ComponentModel.DataAnnotations;

namespace AS_l2.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Lead { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public decimal Kwota { get; set; }
    }
}
