namespace Kolokwium.Services.DTO.Client
{
    public class ClientDto
    {
        public int Id {get; set;}
        public DateTime RegistrationDate {get; set; }
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;

        public string Email {get; set;} = string.Empty;

        public string Phone {get; set;} = string.Empty;

        public List<string> Orders {get; set; } = new();
    }
}