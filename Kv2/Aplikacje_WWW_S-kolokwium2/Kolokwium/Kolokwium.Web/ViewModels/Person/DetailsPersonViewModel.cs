using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Person
{
    public class DetailsPersonViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public int Age { get; set; }
    }
}
