using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.EventType
{
    public class DetailsEventTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa typu wydarzenia")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}
