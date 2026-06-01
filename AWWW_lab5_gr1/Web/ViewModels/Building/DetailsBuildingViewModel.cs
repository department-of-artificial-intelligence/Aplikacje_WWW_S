using System.Collections.Generic;
//using Web.ViewModels.Room;

namespace Web.ViewModels.Building
{
    public class DetailsBuildingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }

        //public List<RoomViewModel> Rooms { get; set; } = new();
    }
}