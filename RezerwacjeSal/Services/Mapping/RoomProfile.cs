using AutoMapper;
using Model.DataModels;
using Services.DTO.Room;

namespace Services.Mapping
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(d => d.BuildingName, o => o.MapFrom(s => s.Building != null ? s.Building.Name : string.Empty));
            CreateMap<Room, RoomDetailsDto>()
                .ForMember(d => d.BuildingName, o => o.MapFrom(s => s.Building != null ? s.Building.Name : string.Empty))
                .ForMember(d => d.Equipment, o => o.MapFrom(s => s.RoomEquipments));
            CreateMap<CreateRoomDto, Room>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Building, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore())
                .ForMember(d => d.RoomEquipments, o => o.Ignore());
            CreateMap<UpdateRoomDto, Room>()
                .ForMember(d => d.Building, o => o.Ignore())
                .ForMember(d => d.Reservations, o => o.Ignore())
                .ForMember(d => d.RoomEquipments, o => o.Ignore());
        }
    }
}
