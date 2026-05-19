using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Services.DTO.Event {
    public class EventDTO {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ParticipantsLimit { get; set; }
        public bool isPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EventTypeId { get; set; }
    }
}
