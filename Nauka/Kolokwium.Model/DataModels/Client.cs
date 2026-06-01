namespace Kolokwium.Model.DataModels
{
    public class Client
    {
        public int Id {get; set;}
        public DateTime RegistrationDate {get; set; }
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;

        public string Email {get; set;} = string.Empty;

        public string Phone {get; set;} = string.Empty;

        public virtual ICollection<Order> Orders {get; set; } = new List<Order>();
    }
}