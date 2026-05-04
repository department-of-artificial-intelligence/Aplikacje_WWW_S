namespace Services.DTO.Equipment
{
    public class UpdateEquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsMobile { get; set; }
    }
}