using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParticipantsLimit { get; set; }
        public bool isPublic { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("EventType")]
        public int EventTypeId { get; set; }

        public virtual EventType EventType { get; set; }

    }
}
