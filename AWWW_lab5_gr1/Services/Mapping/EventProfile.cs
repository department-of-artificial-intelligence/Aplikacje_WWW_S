using AutoMapper;
using Model.DataModels;
using Services.DTO.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.TypeName, o => o.MapFrom(s => s.EventType.Name));

            CreateMap<Event, EventDetailsDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.TypeName, o => o.MapFrom(s => s.EventType.Name));

            CreateMap<CreateEventDto, Event>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.Now))
                .ForMember(d => d.EventType, o => o.Ignore()) 
                .ForMember(d => d.Reservations, o => o.Ignore()); 

            CreateMap<UpdateEventDto, Event>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CreatedAt, o => o.Ignore()) 
                .ForMember(d => d.EventType, o => o.Ignore()) 
                .ForMember(d => d.Reservations, o => o.Ignore()); 
        }
    }
}
