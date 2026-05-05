using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.DataModels
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public int ParticipantsLimit { get; set; }

        public bool IsPublic { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int EventTypeId { get; set; }

        [ForeignKey("EventTypeId")]
        public virtual EventType? EventType { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
