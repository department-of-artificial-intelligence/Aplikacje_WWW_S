

namespace kolos
{
    public class Biblioteka 
    {
        public int id;
        public string nazwa;
        public int numer;
        public string adres;

        public ICollection<Ksiazka> Ksiazki;

    }
}

namespace kolos
{
    public class Ksiazka
    {
        public int id;
        public string tytul;
        public string wydawnictwo;
        public int rokWydania;
        public int numerWydania;
        public virtual Biblioteka Biblioteka;
        public int BibliotekaId; 
        public ICollection<Kategoria> Kategorie;
    }
}

namespace kategoria
{
    public class Kategoria
    {
        public int id;
        public string nazwa;
        public ICollection<Ksiazka> Ksiazki;
    }
}