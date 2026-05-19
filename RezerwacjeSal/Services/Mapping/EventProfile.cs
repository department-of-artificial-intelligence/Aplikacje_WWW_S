using AutoMapper;
using Model.DataModels;
using Services.DTO.Event;

namespace Services.Mapping
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(d => d.EventTypeName, o => o.MapFrom(s => s.EventType != null ? s.EventType.Name : string.Empty));
            CreateMap<Event, EventDetailsDto>()
                .ForMember(d => d.EventTypeName, o => o.MapFrom(s => s.EventType != null ? s.EventType.Name : string.Empty));
            CreateMap<CreateEventDto, Event>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.EventType, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore());
            CreateMap<UpdateEventDto, Event>()
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.EventType, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore());
        }
    }
}
