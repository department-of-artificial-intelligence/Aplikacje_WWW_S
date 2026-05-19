using AutoMapper;
using Model.DataModels;
using Services.DTO.Room;

namespace Services.Mapping
{
    public class RoomEquipmentProfile : Profile
    {
        public RoomEquipmentProfile()
        {
            CreateMap<RoomEquipment, RoomEquipmentItemDto>()
                .ForMember(d => d.RoomName, o => o.MapFrom(s => s.Room != null ? s.Room.Name : string.Empty))
                .ForMember(d => d.EquipmentName, o => o.MapFrom(s => s.Equipment != null ? s.Equipment.Name : string.Empty));

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
