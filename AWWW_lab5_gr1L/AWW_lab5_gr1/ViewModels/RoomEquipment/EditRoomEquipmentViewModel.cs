using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.RoomEquipment
{
    public class EditRoomEquipmentViewModel
    {
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }

        public string? RoomName { get; set; }
        public string? EquipmentName { get; set; }

        [Display(Name = "Ilość")]
        [Range(1, int.MaxValue, ErrorMessage = "Ilość musi być większa od zera.")]
        public int Quantity { get; set; }
    }
}
