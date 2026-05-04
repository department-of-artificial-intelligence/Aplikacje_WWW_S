namespace Services.DTO.EventType
{
    public class EventTypeDto { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; }
    public class CreateEventTypeDto { public string Name { get; set; } = null!; public string Description { get; set; } = null!; }
    public class UpdateEventTypeDto { public int Id { get; set; } public string Name { get; set; } = null!; public string Description { get; set; } = null!; }
}