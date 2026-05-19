using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Building
{
    public class DetailsBuildingViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; } = null!;

        [Display(Name = "Adres")]
        public string Address { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        public List<BuildingRoomItemViewModel> Rooms { get; set; } = new();
    }

    public class BuildingRoomItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }
    }
}
