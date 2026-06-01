namespace Kolokwium.Model.DataModels
{
    public class Address
    {
        public int Id{get;set;}
        public string Country{get;set;} = string.Empty;
        public string City{get;set;} = string.Empty;
        public string Street{get;set;} = string.Empty;
        public string ZipCode{get;set;} = string.Empty;
        public int BuildingNumber{get;set;}
        public int? ApartmentNumber{get;set;}

        public virtual ICollection<Order> Orders {get;set;} = new List<Order>();
        

    }
}