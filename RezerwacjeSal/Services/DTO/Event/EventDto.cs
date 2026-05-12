namespace Services.DTO.Event
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int EventTypeId { get; set; }
        public string EventTypeName { get; set; } = null!;
    }
}
