using Model;
using Services.DTO.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Services.Mapping
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name))
                .ForMember(d => d.EventTitle, o => o.MapFrom(s => s.Event.Title))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            CreateMap<Reservation, Services.DTO.Event.ReservationDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

            CreateMap<CreateReservationDto, Reservation>();
            CreateMap<UpdateReservationDto, Reservation>();
        }
    }
}
