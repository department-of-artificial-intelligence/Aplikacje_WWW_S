using AutoMapper;
using Model.DataModels;
using Services.DTO.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
