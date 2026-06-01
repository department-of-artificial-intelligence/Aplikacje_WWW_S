using System.Linq;

namespace Kolokwium.Model.DataModels
{
    public class Order
    {
        public int Id {get; set; }
        public DateTime OrderDate {get; set;}
        public DateTime DeliveryDate {get; set;}
        public decimal TotalPrice { get; }
        public virtual Address? DeliveryAddress {get; set;} 

        public int DeliveryAddressId {get; set;}
        
        public virtual ICollection<Meal> Meals {get; set;} = new List<Meal>();
    }
}