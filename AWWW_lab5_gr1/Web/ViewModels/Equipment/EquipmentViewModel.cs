using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Equipment
{
    public class EquipmentListItemViewModel { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; [Display(Name = "Mobilne")] public bool IsMobile { get; set; } }
    public class EquipmentDetailsViewModel { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; [Display(Name = "Mobilne")] public bool IsMobile { get; set; } }
    public class DeleteEquipmentViewModel { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; [Display(Name = "Mobilne")] public bool IsMobile { get; set; } }

    public class CreateEquipmentViewModel
    {
        [Display(Name = "Nazwa")][Required(ErrorMessage = "Pole Nazwa jest wymagane.")] public string Name { get; set; } = null!;
        [Display(Name = "Opis")][Required(ErrorMessage = "Pole Opis jest wymagane.")] public string Description { get; set; } = null!;
        [Display(Name = "Sprzęt mobilny")] public bool IsMobile { get; set; }
    }

    public class EditEquipmentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")][Required(ErrorMessage = "Pole Nazwa jest wymagane.")] public string Name { get; set; } = null!;
        [Display(Name = "Opis")][Required(ErrorMessage = "Pole Opis jest wymagane.")] public string Description { get; set; } = null!;
        [Display(Name = "Sprzęt mobilny")] public bool IsMobile { get; set; }
    }
}