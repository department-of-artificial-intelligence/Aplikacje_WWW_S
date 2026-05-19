using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.EventType
{
    public class CreateEventTypeViewModel
    {
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [Display(Name = "Nazwa typu wydarzenia")]
        [StringLength(100, ErrorMessage = "Nazwa nie może przekraczać 100 znaków.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }
}
