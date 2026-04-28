namespace Services.DTOs
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMobile { get; set; }
    }
}