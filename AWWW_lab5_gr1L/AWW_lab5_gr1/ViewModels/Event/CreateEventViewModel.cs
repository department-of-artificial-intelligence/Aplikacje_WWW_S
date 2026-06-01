using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Event
{
    public class CreateEventViewModel
    {
        [Required(ErrorMessage = "Tytuł wydarzenia jest wymagany.")]
        [Display(Name = "Tytuł wydarzenia")]
        public string Title { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Limit uczestników jest wymagany.")]
        [Display(Name = "Limit uczestników")]
        [Range(1, int.MaxValue, ErrorMessage = "Limit musi być większy od 0.")]
        public int ParticipantsLimit { get; set; }

        [Display(Name = "Wydarzenie publiczne")]
        public bool IsPublic { get; set; }

        [Required(ErrorMessage = "Musisz wybrać typ wydarzenia.")]
        [Display(Name = "Typ wydarzenia")]
        public int EventTypeId { get; set; }

        public List<SelectListItem> EventTypes { get; set; } = new();
    }
}
