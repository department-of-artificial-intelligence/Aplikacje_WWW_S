using AutoMapper;
using Model;
using Services.DTO.RoomEquipment;

namespace Services.Mapping
{
    public class RoomEquipmentProfile : Profile
    {
        public RoomEquipmentProfile()
        {
            CreateMap<RoomEquipment, RoomEquipmentItemDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room.Name))
                .ForMember(d => d.EquipmentName, o => o.MapFrom(s => s.Equipment.Name));

            CreateMap<CreateRoomEquipmentDto, RoomEquipment>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Room, o => o.Ignore())
                .ForMember(d => d.Equipment, o => o.Ignore());

            CreateMap<UpdateRoomEquipmentDto, RoomEquipment>()
                .ForMember(d => d.RoomId, o => o.Ignore())
                .ForMember(d => d.Room, o => o.Ignore())
                .ForMember(d => d.EquipmentId, o => o.Ignore())
                .ForMember(d => d.Equipment, o => o.Ignore());
        }
    }
}