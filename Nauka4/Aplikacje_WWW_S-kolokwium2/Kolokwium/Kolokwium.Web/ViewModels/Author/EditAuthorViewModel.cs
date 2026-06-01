using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Author
{
    public class EditAuthorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię i Nazwisko jest wymagane.")]
        [Display(Name = "Imię i Nazwisko autora")]
        public string FullName { get; set; } = null!;
    }
}
