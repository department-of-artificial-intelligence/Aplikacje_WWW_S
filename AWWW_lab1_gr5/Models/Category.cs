using System.Data;
namespace AWWW_lab1_gr5.Models
{
    public class Category
    {
        public int Id {get; set;}
        public string Name {get; set;} = null!;
        public virtual ICollection<Article>? Articles {get; set;}
    }
}