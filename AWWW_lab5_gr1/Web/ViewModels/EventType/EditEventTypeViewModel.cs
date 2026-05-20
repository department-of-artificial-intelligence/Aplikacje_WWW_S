using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.EventType
{
    public class EditEventTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [Display(Name = "Nazwa typu wydarzenia")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}