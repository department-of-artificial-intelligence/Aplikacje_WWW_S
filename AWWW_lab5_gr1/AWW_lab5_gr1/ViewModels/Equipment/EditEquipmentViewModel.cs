using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Equipment
{
    public class EditEquipmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [Display(Name = "Nazwa wyposażenia")]
        [StringLength(100, ErrorMessage = "Nazwa nie może przekraczać 100 znaków.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = "Sprzęt mobilny?")]
        public bool IsMobile { get; set; }
    }
}
