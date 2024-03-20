using System.Net.Mime;
namespace AWWW_lab2_gr2.Models;

public class Tag{
       public int Id{get; set;}

       [StringLength(50)]
       [Display(Name = "Name")]
       public string Name{get; set;} = null!;

       public virtual ICollection<Article>? Articles { get; set; }
}