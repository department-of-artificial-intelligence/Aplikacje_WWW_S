using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Driver
{
    public class EditDriverViewModel
    {
        public int Id { get; set; } // Ukryte pole w HTML <input type="hidden" />

        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string LastName { get; set; } = null!;
    }
}
