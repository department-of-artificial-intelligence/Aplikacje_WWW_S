using Web.ViewModels.Room;

namespace Web.ViewModels.Building
{
    public class BuildingDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }
        public List<RoomListItemViewModel> Rooms { get; set; } = new();
    }
}
