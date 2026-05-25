using AutoMapper;
using Services.DTO.Room;

using Web.ViewModels.Room;

namespace Web.Mapping
{
    public class RoomViewModelProfile : Profile
    {
        public RoomViewModelProfile()
        {
            CreateMap<RoomDto, RoomListItemViewModel>();

            CreateMap<RoomDto, RoomDetailsViewModel>()
                .ForMember(d => d.Equipment, o => o.Ignore());

            CreateMap<Services.DTO.RoomEquipment.RoomEquipmentItemDto, RoomEquipmentItemViewModel>();

            CreateMap<RoomDto, EditRoomViewModel>()
                .ForMember(d => d.Buildings, o => o.Ignore());

            CreateMap<RoomDto, DeleteRoomViewModel>();

            CreateMap<CreateRoomViewModel, CreateRoomDto>();
            CreateMap<EditRoomViewModel, UpdateRoomDto>();
        }
    }
}