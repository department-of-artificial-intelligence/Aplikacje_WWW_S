namespace Services.DTO.Room
{
    public class CreateRoomDto
    {
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; } = true;
        public int BuildingId { get; set; }
    }
}
