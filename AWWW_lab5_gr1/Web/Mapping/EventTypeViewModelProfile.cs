using AutoMapper;
using Services.DTO.EventType;
using Web.ViewModels.EventType;

namespace Web.Mapping
{
    public class EventTypeViewModelProfile : Profile
    {
        public EventTypeViewModelProfile()
        {
            CreateMap<EventTypeDto, EventTypeListItemViewModel>();
            CreateMap<EventTypeDto, EventTypeDetailsViewModel>();
            CreateMap<EventTypeDto, EditEventTypeViewModel>();
            CreateMap<EventTypeDto, DeleteEventTypeViewModel>();

            CreateMap<CreateEventTypeViewModel, CreateEventTypeDto>();
            CreateMap<EditEventTypeViewModel, UpdateEventTypeDto>();
        }
    }
}