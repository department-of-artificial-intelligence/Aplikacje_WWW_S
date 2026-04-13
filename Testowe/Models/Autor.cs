namespace Kolokwium.Models
{
    public class Autor
    {
        public int Id{get;set;}
        public string? Nazwisko{get;set;}
        public List<Ksiazka>? Ksiazki{get;set;}=new List<Ksiazka>();
        
    }
}