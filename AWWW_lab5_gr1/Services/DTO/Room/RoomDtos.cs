namespace Services.DTO.Room
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; } = null!;
    }

    public class RoomEquipmentItemDto
    {
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = null!;
        public int Quantity { get; set; }
    }

    public class RoomDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; } = null!;
        public List<RoomEquipmentItemDto> Equipment { get; set; } = new();
    }

    public class CreateRoomDto
    {
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; } = true;
        public int BuildingId { get; set; }
    }

    public class UpdateRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }
        public int BuildingId { get; set; }
    }
}