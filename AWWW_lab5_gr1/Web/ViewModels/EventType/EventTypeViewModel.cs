using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.EventType
{
    public class EventTypeListItemViewModel { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; }
    public class EventTypeDetailsViewModel { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; }
    public class DeleteEventTypeViewModel { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; }

    public class CreateEventTypeViewModel
    {
        [Display(Name = "Nazwa")][Required(ErrorMessage = "Pole Nazwa jest wymagane.")] public string Name { get; set; } = null!;
        [Display(Name = "Opis")][Required(ErrorMessage = "Pole Opis jest wymagane.")] public string Description { get; set; } = null!;
    }

    public class EditEventTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")][Required(ErrorMessage = "Pole Nazwa jest wymagane.")] public string Name { get; set; } = null!;
        [Display(Name = "Opis")][Required(ErrorMessage = "Pole Opis jest wymagane.")] public string Description { get; set; } = null!;
    }
}