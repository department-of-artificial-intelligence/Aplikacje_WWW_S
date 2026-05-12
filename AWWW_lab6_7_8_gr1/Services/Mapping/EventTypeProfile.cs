using AutoMapper;
using Model.Entities;
using Services.DTO.EventType;

namespace Services.Mapping
{
    public class EventTypeProfile : Profile
    {
        public EventTypeProfile()
        {
            CreateMap<EventType, EventTypeDto>();

            CreateMap<CreateEventTypeDto, EventType>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Events, o => o.Ignore());

            CreateMap<UpdateEventTypeDto, EventType>()
                .ForMember(d => d.Events, o => o.Ignore());
        }
    }
}