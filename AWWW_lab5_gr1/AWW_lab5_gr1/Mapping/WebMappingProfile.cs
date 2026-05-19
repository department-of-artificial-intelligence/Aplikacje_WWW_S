using AutoMapper;
using Services.DTO.Building;
using Services.DTO.Equipment;
using Services.DTO.EventType;
using Services.DTO.Room;
using Web.ViewModels.Building;
using Web.ViewModels.Equipment;
using Web.ViewModels.EventType;
using Web.ViewModels.Room;

namespace Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<BuildingDto, IndexBuildingViewModel>();  
            CreateMap<BuildingDto, EditBuildingViewModel>();   
            CreateMap<BuildingDto, DeleteBuildingViewModel>();
            CreateMap<BuildingDto, DetailsBuildingViewModel>()
            .ForMember(dest => dest.Rooms, opt => opt.Ignore());

            CreateMap<CreateBuildingViewModel, CreateBuildingDto>(); 
            CreateMap<EditBuildingViewModel, BuildingDto>();         

            CreateMap<RoomDto, BuildingRoomItemViewModel>();

           
            CreateMap<EventTypeDto, IndexEventTypeViewModel>();
            CreateMap<EventTypeDto, EditEventTypeViewModel>();
            CreateMap<EventTypeDto, DeleteEventTypeViewModel>();
            CreateMap<EventTypeDto, DetailsEventTypeViewModel>();

            CreateMap<CreateEventTypeViewModel, CreateEventTypeDto>();
            CreateMap<EditEventTypeViewModel, UpdateEventTypeDto>();

            
            CreateMap<EquipmentDto, IndexEquipmentViewModel>();
            CreateMap<EquipmentDto, EditEquipmentViewModel>();
            CreateMap<EquipmentDto, DeleteEquipmentViewModel>();
            CreateMap<EquipmentDto, DetailsEquipmentViewModel>();

            CreateMap<CreateEquipmentViewModel, CreateEquipmentDto>();
            CreateMap<EditEquipmentViewModel, EquipmentDto>();
            CreateMap<EditEquipmentViewModel, UpdateEquipmentDto>();


            CreateMap<RoomDto, IndexRoomViewModel>();
            CreateMap<RoomDto, DetailsRoomViewModel>();
            CreateMap<RoomDto, DeleteRoomViewModel>();
            CreateMap<RoomDto, EditRoomViewModel>()
                .ForMember(dest => dest.Buildings, opt => opt.Ignore());

            CreateMap<RoomDetailsDto, IndexRoomViewModel>();
            CreateMap<RoomDetailsDto, DetailsRoomViewModel>();
            CreateMap<RoomDetailsDto, DeleteRoomViewModel>();
            CreateMap<RoomDetailsDto, EditRoomViewModel>()
                .ForMember(dest => dest.Buildings, opt => opt.Ignore());

            CreateMap<EditRoomViewModel, RoomDto>()
                .ForMember(dest => dest.BuildingName, opt => opt.Ignore());

            CreateMap<EditRoomViewModel, UpdateRoomDto>(MemberList.None);

            CreateMap<CreateRoomViewModel, CreateRoomDto>();
        }
    }
}
