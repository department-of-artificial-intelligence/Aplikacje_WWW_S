using System.Net.NetworkInformation;

namespace AWWW_lab1_gr5.Models{
    public class Author{
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        //klucz obcy 1-*
        public virtual ICollection<Article> Articles {get;set;}
    }
}