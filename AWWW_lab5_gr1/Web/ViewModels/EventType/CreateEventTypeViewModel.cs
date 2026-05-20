using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.EventType
{
    public class CreateEventTypeViewModel
    {
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [Display(Name = "Nazwa typu wydarzenia")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}