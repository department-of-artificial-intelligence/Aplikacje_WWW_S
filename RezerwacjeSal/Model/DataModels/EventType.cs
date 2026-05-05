using System.ComponentModel.DataAnnotations;

namespace Model.DataModels
{
    public class EventType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
