using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataModels
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParticipantsLimit { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
