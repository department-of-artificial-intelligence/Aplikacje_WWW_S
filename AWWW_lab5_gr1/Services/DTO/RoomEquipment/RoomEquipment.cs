namespace Services.DTO.RoomEquipment
{
    public class CreateRoomEquipmentDto
    {
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateRoomEquipmentDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }

    public class RoomEquipmentItemDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
    }
}