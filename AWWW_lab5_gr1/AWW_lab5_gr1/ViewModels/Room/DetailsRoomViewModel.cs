using System.ComponentModel.DataAnnotations;
using Web.ViewModels.RoomEquipment;

namespace Web.ViewModels.Room
{
    public class DetailsRoomViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa sali")]
        public string Name { get; set; } = null!;

        [Display(Name = "Przypisany budynek")]
        public string BuildingName { get; set; } = null!;

        [Display(Name = "Maksymalna pojemność")]
        public int Capacity { get; set; }

        [Display(Name = "Lokalizacja (Piętro)")]
        public int Floor { get; set; }

        [Display(Name = "Status dostępności")]
        public bool IsActive { get; set; }

        public List<RoomEquipmentItemViewModel> Equipment { get; set; } = new();
    }
}
