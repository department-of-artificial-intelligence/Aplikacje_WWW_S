using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Equipment
{
    public class EditEquipmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}