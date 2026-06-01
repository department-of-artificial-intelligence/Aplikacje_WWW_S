using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Driver
{
    public class DeleteDriverViewModel
    {
        public int Id { get; set; } // Wymagane, aby przesłać ID do akcji POST

        [Display(Name = "Imię kierowcy")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Nazwisko kierowcy")]
        public string LastName { get; set; } = null!;
    }
}
