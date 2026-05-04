namespace Services.DTO.Equipment
{
    public class EquipmentDto { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; public bool IsMobile { get; set; } }
    public class CreateEquipmentDto { public string Name { get; set; } = null!; public string Description { get; set; } = null!; public bool IsMobile { get; set; } }
    public class UpdateEquipmentDto { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; public bool IsMobile { get; set; } }
}