namespace Services.DTO.Event
{
    public class CreateEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public int EventTypeId { get; set; }
    }
}