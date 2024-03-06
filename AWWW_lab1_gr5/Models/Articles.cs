using System.Net.NetworkInformation;

namespace AWWW_lab1_gr5.Models{
    public class Article{
        public int Id {get;set;}
        public string Title {get;set;} = null!;
        public string Content {get;set;} = null!;
        public DateTime CreationDate {get;set;}
    }
}