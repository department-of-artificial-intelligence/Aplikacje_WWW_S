namespace AWWW_lab2_gr1.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; } //N:N, wiele produktow wiele tagow; nie wymaga klucza obcego
    }
}
