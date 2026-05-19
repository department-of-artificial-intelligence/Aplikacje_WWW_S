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

            CreateMap<CreateEventDto, Event>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.EventType, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore());

            CreateMap<UpdateEventDto, Event>()
                .ForMember(d => d.CreatedAt, o => o.Ignore()) // Data utworzenia z reguły się nie zmienia
                .ForMember(d => d.EventType, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore());
        }
    }
}