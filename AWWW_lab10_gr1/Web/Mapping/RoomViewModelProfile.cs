using AutoMapper;
using Services.DTO.Room;
using Services.DTO.RoomEquipment;
using Web.ViewModels.Room;

namespace Web.Mapping
{
    public class RoomViewModelProfile : Profile
    {
        public RoomViewModelProfile()
        {
            CreateMap<RoomDto, RoomListItemViewModel>();
            CreateMap<RoomDetailsDto, RoomDetailsViewModel>();
            CreateMap<RoomEquipmentDto, RoomEquipmentItemViewModel>();
            CreateMap<RoomDetailsDto, EditRoomViewModel>()
                .ForMember(d => d.Buildings, o => o.Ignore());
            CreateMap<RoomDetailsDto, DeleteRoomViewModel>();

            CreateMap<CreateRoomViewModel, CreateRoomDto>();
            CreateMap<EditRoomViewModel, UpdateRoomDto>();

        }
    }
}
