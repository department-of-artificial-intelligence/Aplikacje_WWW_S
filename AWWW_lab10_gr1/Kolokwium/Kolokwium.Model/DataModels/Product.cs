using System.Collections.Generic;


namespace Kolokwium.Model.DataModels
{
    public class Product
    {
        public int Id {get; set; }
        public string Name {get; set; } = string.Empty;
        public decimal Price {get; set; }
        public int CategoryId {get; set; }
        public virtual Category Category {get; set; } = new Category();

        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}