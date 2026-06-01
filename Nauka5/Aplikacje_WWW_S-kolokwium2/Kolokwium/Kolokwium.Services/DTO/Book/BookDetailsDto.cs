using Kolokwium.Model.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Kolokwium.Services.DTO.Book
{
   public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;

        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;

        // Relacja M:N - kolekcja autorów przypisanych do danej książki
        public List<Author> Authors { get; set; } = new();// Jakby bylo 1 do 1 to po prostu public Author Authors


        /*Jeśli w BookDetailsDto zamienisz to na List<string>, 
         to w kontrolerze stracisz informację o identyfikatorach ID aktualnych autorów ksiązki(bo masz tylko ich imiona jako tekst).
         Formularz edycji otworzy się z...zupełnie pustymi checkboxami.*/
        //public List<string> AuthorNames { get; set; } = new(); // Pod widok Details 
        //public List<int> AuthorIds { get; set; } = new();     // Pod widok Edit
        //I wtedy w mapowaniu bazy danych musiałbyś mapować obie te listy na raz.
    }
}
