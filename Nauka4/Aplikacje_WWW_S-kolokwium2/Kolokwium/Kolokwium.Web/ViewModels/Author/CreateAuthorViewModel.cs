using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Author
{
    public class CreateAuthorViewModel
    {
        [Required(ErrorMessage = "Imię i Nazwisko jest wymagane.")]
        [Display(Name = "Imię i Nazwisko autora")]
        public string FullName { get; set; } = null!;
    }
}
