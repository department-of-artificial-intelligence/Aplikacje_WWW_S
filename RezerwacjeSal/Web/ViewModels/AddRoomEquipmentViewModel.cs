namespace Web.ViewModels.RoomEquipment;
public class AddRoomEquipmentsViewModel
{
    public int RoomId {get; set;}
    public string? RoomName {get; set;}

    public string? BuildingName {get; set;}

    public List<AddRoomEquipmentsViewModel> Items {get; set;} = new ();








    
}