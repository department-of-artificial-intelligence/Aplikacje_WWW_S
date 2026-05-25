using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Model.DataModels
{
    public class Category
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;

        public virtual ICollection<Product> Products {get; set;} = new List<Product>();
    }
}