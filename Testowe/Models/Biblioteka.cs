namespace Kolokwium.Models
{
    public class Biblioteka
    {
        public int Id { get; set; }
        public string? Nazwa { get; set; }
        public List<Ksiazka>? Ksiazki { get; set; } = new List<Ksiazka>();
    }
}