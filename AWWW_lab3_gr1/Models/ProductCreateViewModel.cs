namespace AWWW_lab3_gr1.Models
{
    public class ProductCreateViewModel
    {
        // dane produktu
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        // dropdown + multi-select
        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }

        // wybrane tagi z formularza
        public List<int> SelectedTagIds { get; set; } = new();
    }
}