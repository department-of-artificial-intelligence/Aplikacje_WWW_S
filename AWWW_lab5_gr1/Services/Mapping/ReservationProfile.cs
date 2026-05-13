using AutoMapper;
using Model.DataModels;
using Services.DTO.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name))
                .ForMember(d => d.EventTitle, o => o.MapFrom(s => s.Event.Title));

            CreateMap<Reservation, ReservationDetailsDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name))
                .ForMember(d => d.EventTitle, o => o.MapFrom(s => s.Event.Title));

            CreateMap<CreateReservationDto, Reservation>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Status, o => o.MapFrom(s => ReservationStatus.Pending))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => DateTime.Now))
                .ForMember(d => d.Room, o => o.Ignore()) 
                .ForMember(d => d.Event, o => o.Ignore());

            CreateMap<UpdateReservationDto, Reservation>()
            .ForMember(d => d.Room, o => o.Ignore()) 
            .ForMember(d => d.Event, o => o.Ignore()) 
            .ForMember(d => d.CreatedAt, o => o.Ignore());
        }
    }
}
