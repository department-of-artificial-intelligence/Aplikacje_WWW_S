using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Model;
using Services.DTO.Building;
using Services.DTO.Room;

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

            CreateMap<CreateRoomDto, Room>();
            CreateMap<UpdateRoomDto, Room>();
        }
    }
}
