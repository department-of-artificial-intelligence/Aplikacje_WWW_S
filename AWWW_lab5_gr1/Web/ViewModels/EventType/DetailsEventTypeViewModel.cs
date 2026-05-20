using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.EventType
{
    public class DetailsEventTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa typu wydarzenia")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }

        public List<EventTypeEventItemViewModel> Events { get; set; } = new();
    }

    public class EventTypeEventItemViewModel
    {
        public string Name { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public string RoomName { get; set; } = null!;
    }
}