namespace Kolokwium.Models
{
    public class Ksiazka
    {
        public int Id { get; set; }
        public string? Tytul { get; set; }
        public int BibliotekaId { get; set; }
        public Biblioteka? Biblioteka { get; set; }
        public List<Autor>? Autorzy { get; set; } = new List<Autor>();
    }
}