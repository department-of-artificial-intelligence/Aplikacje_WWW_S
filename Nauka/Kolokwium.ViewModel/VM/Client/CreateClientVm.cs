namespace Kolokwium.ViewModel.VM.Client
{
    public class CreateClientVm
    {
        public DateTime RegistrationDate {get; set; }
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;

        public string Email {get; set;} = string.Empty;

        public string Phone {get; set;} = string.Empty;

        public List<int> OrderIds {get; set; } = new();
    }
}