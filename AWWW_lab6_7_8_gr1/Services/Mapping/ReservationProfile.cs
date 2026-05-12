using AutoMapper;
using Model.Entities;
using Services.DTO.Reservation;

namespace Services.Mapping
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name));

            CreateMap<CreateReservationDto, Reservation>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Status, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Room, o => o.Ignore())
                .ForMember(d => d.Event, o => o.Ignore());

            CreateMap<UpdateReservationDto, Reservation>()
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.Room, o => o.Ignore())
                .ForMember(d => d.Event, o => o.Ignore());
        }
    }
}