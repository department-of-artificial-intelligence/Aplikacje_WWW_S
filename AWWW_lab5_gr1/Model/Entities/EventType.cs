using System.Collections.Generic;

namespace Model.Entities
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Relacja 1:N z Event
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}