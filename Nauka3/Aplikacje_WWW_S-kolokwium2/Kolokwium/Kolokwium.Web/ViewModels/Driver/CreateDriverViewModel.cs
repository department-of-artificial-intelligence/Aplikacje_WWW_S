using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Driver
{
    public class CreateDriverViewModel
    {
        [Required(ErrorMessage = "Imię jest wymagane.")]
        [Display(Name = "Imię kierowcy")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        [Display(Name = "Nazwisko kierowcy")]
        public string LastName { get; set; } = null!;
    }
}
