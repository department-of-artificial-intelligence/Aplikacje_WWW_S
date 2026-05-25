using AutoMapper;
using Model.DataModels;
using Services.DTO.Event;
using Services.DTO.Reservation;

namespace Services.Mapping
{
    public class EventAndReservationProfile : Profile
    {
        public EventAndReservationProfile()
        {
            // Event
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
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.EventType, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore());

            // Reservation
            CreateMap<Reservation, ReservationDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name));

            CreateMap<Reservation, ReservationListDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name))
                .ForMember(d => d.EventTitle, o => o.MapFrom(s => s.Event.Title));

            CreateMap<CreateReservationDto, Reservation>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Status, o => o.Ignore())
                .ForMember(d => d.Room, o => o.Ignore())
                .ForMember(d => d.Event, o => o.Ignore());

            CreateMap<UpdateReservationDto, Reservation>()
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Room, o => o.Ignore())
                .ForMember(d => d.Event, o => o.Ignore());
        }
    }
}