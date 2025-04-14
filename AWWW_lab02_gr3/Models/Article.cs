namespace AWWW_lab02_gr3.Models
{
    public class Article
    {
        public int Id {get; set; }
        public string Title { get; set; } = null!;
        public string Content {get; set; } = null!;
        public DateTime CreationDate { get; set; }
        
        public ICollection<Comment>? Comments {get; set;}
//po to zeby odnalezc sie w swoim kodzie
//nie warto, kiedy jest to maly projekt (nie bedzie rozwijany)
//dal - komunikacja z wartwa prezentacji i komunikacji
//viewmodel - 
//services - aplikacja webowa + api, jedna metoda, ktora bedzie wyswietlac srednia ocen bedzie z api i z weba. dostępne w wielu miejscach
//test- fremweork testujacy uslugi (viewmodele i services). umozliwia testowanie funkcjonalnosci (czy sredni sie dobrze policzyla, itd.)
//web(app mvc) - dostep do wszystkiego poza testem (model, viewmodel, services, dal).
        public ICollection<Tag>? Tags {get; set;}

        public int AuthorId {get; set;}
        public Author Author {get; set;} = null!;
        
        public int CategoryId {get; set;}
        public Category Category {get; set;} = null!;
        
        public int? MatchId {get; set;}
        public Match? Match {get; set;}
    }
}