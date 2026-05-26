using AutoMapper;
using Services.DTO.Building;
using Services.DTO.EventType;
using Services.DTO.Equipment;
using Services.DTO.Room;
using Web.ViewModels.Building;
using Web.ViewModels.EventType;
using Web.ViewModels.Equipment;
using Web.ViewModels.Room;

namespace Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            // 1. Mapowania dla budynku (Building)
            CreateMap<BuildingDto, BuildingViewModel>();
            CreateMap<BuildingDto, EditBuildingViewModel>();

            CreateMap<BuildingDto, DetailsBuildingViewModel>()
                .ForMember(d => d.Rooms, o => o.Ignore());

            CreateMap<CreateBuildingViewModel, CreateBuildingDto>();
            CreateMap<EditBuildingViewModel, UpdateBuildingDto>();

            // 2. Mapowania dla typu wydarzenia (EventType) 
            CreateMap<EventTypeDto, EventTypeViewModel>();
            CreateMap<EventTypeDto, EditEventTypeViewModel>();

            // ROZWIĄZANIE OSTATNIEGO BŁĘDU:
            // Nakazujemy AutoMapperowi zignorować kolekcję Events, ponieważ dociągniesz ją ręcznie
            CreateMap<EventTypeDto, DetailsEventTypeViewModel>()
                .ForMember(d => d.Events, o => o.Ignore());

            CreateMap<CreateEventTypeViewModel, CreateEventTypeDto>();
            CreateMap<EditEventTypeViewModel, UpdateEventTypeDto>();

            // 3. Mapowania dla wyposażenia (Equipment)
            CreateMap<EquipmentDto, EquipmentViewModel>();
            CreateMap<EquipmentDto, EditEquipmentViewModel>();
            CreateMap<EquipmentDto, DetailsEquipmentViewModel>();

            CreateMap<CreateEquipmentViewModel, CreateEquipmentDto>();
            CreateMap<EditEquipmentViewModel, UpdateEquipmentDto>();

            // 4. Mapowania dla sali (Room)
            CreateMap<RoomDto, RoomViewModel>();

            CreateMap<RoomDetailsDto, EditRoomViewModel>()
                .ForMember(d => d.Buildings, o => o.Ignore());

            CreateMap<RoomDetailsDto, DetailsRoomViewModel>();
            CreateMap<RoomEquipmentItemDto, RoomEquipmentItemViewModel>();

            CreateMap<CreateRoomViewModel, CreateRoomDto>();
            CreateMap<EditRoomViewModel, UpdateRoomDto>();
        }
    }
}