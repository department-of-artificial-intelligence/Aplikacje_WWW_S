using AutoMapper;
using Model.DataModels;
using Services.DTO.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(d => d.BuildingName, o => o.MapFrom(s => s.Building.Name));

            CreateMap<Room, RoomDetailsDto>()
                .ForMember(d => d.BuildingName, o => o.MapFrom(s => s.Building.Name))
                .ForMember(d => d.Equipment, o => o.MapFrom(s => s.RoomEquipments));

            CreateMap<RoomEquipment, RoomEquipmentItemDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.EquipmentId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Equipment.Name));

            CreateMap<CreateRoomDto, Room>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Building, o => o.Ignore())
                .ForMember(d => d.RoomEquipments, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore()); 

            CreateMap<UpdateRoomDto, Room>()
                .ForMember(d => d.Building, o => o.Ignore())
                .ForMember(d => d.RoomEquipments, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore()); 
        }
    }
}
