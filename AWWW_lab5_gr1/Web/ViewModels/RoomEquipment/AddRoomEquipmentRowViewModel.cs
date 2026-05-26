using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.RoomEquipment
{
    public class AddRoomEquipmentRowViewModel
    {
        public int RoomId { get; set; }

        public int EquipmentId { get; set; }

        public string? EquipmentName { get; set; }

        public string? Description { get; set; }

        public bool IsMobile { get; set; }

        [Display(Name = "Dodaj")]
        public bool IsSelected { get; set; }

        [Display(Name = "Ilość")]
        [Range(1, int.MaxValue, ErrorMessage = "Ilość musi być większa od zera.")]
        public int Quantity { get; set; } = 1;
    }
}
