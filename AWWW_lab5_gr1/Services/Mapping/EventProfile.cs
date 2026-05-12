using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Model;
using Services.DTO.Event;

namespace Services.Mapping
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(d => d.EventTypeName, o => o.MapFrom(s => s.EventType.Name));

            CreateMap<Event, EventDetailsDto>()
                .ForMember(d => d.EventTypeName, o => o.MapFrom(s => s.EventType.Name));

            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
        }
    }
}
