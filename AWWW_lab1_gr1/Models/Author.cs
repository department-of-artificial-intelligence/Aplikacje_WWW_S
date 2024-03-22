using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class Author{
        public int ID{get; set;}
        public required string FirstName{get;set;}
        public required string LastName{get;set;}
        public virtual ICollection<Article> Articles{get; set;}
    }
}