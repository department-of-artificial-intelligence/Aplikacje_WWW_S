using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.EventType
{
    public class IndexEventTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}
