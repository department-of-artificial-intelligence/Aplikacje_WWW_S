namespace Services.DTO.Room
{
    public class CreateRoomEquipmentDto
    {
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
    }
}