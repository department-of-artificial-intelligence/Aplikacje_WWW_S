using AutoMapper;
using Services.DTO.Building;
using Services.DTO.Equipment;
using Services.DTO.Event;
using Services.DTO.EventType;
using Services.DTO.Room;
using Web.ViewModels.Building;
using Web.ViewModels.Equipment;
using Web.ViewModels.Event;
using Web.ViewModels.EventType;
using Web.ViewModels.Room;

namespace Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            //Building
            CreateMap<BuildingDto, IndexBuildingViewModel>();  
            CreateMap<BuildingDto, EditBuildingViewModel>();   
            CreateMap<BuildingDto, DeleteBuildingViewModel>();
            CreateMap<BuildingDto, DetailsBuildingViewModel>()
            .ForMember(dest => dest.Rooms, opt => opt.Ignore());

            CreateMap<CreateBuildingViewModel, CreateBuildingDto>(); 
            CreateMap<EditBuildingViewModel, BuildingDto>();         

            CreateMap<RoomDto, BuildingRoomItemViewModel>();

           //Event
            CreateMap<EventTypeDto, IndexEventTypeViewModel>();
            CreateMap<EventTypeDto, EditEventTypeViewModel>();
            CreateMap<EventTypeDto, DeleteEventTypeViewModel>();
            CreateMap<EventTypeDto, DetailsEventTypeViewModel>();

            CreateMap<CreateEventTypeViewModel, CreateEventTypeDto>();
            CreateMap<EditEventTypeViewModel, UpdateEventTypeDto>();

            //Equipment
            CreateMap<EquipmentDto, IndexEquipmentViewModel>();
            CreateMap<EquipmentDto, EditEquipmentViewModel>();
            CreateMap<EquipmentDto, DeleteEquipmentViewModel>();
            CreateMap<EquipmentDto, DetailsEquipmentViewModel>();

            CreateMap<CreateEquipmentViewModel, CreateEquipmentDto>();
            CreateMap<EditEquipmentViewModel, EquipmentDto>();
            CreateMap<EditEquipmentViewModel, UpdateEquipmentDto>();

            //Room
            CreateMap<RoomDto, IndexRoomViewModel>();
            CreateMap<RoomDto, DetailsRoomViewModel>()
                 .ForMember(dest => dest.Equipment, opt => opt.Ignore());
            CreateMap<RoomDto, DeleteRoomViewModel>();
            CreateMap<RoomDto, EditRoomViewModel>()
                .ForMember(dest => dest.Buildings, opt => opt.Ignore());

            CreateMap<RoomDetailsDto, IndexRoomViewModel>();
            CreateMap<RoomDetailsDto, DetailsRoomViewModel>()
                .ForMember(dest => dest.Equipment, opt => opt.Ignore());
            CreateMap<RoomDetailsDto, DeleteRoomViewModel>();
            CreateMap<RoomDetailsDto, EditRoomViewModel>()
                .ForMember(dest => dest.Buildings, opt => opt.Ignore());

            CreateMap<EditRoomViewModel, RoomDto>()
                .ForMember(dest => dest.BuildingName, opt => opt.Ignore());

            CreateMap<EditRoomViewModel, UpdateRoomDto>(MemberList.None);

            CreateMap<CreateRoomViewModel, CreateRoomDto>();

            //Event
            CreateMap<Services.DTO.Event.EventDto, IndexEventViewModel>(MemberList.Destination);

            CreateMap<Services.DTO.Event.EventDto, DetailsEventViewModel>(MemberList.Destination)
                .ForMember(dest => dest.Reservations, opt => opt.Ignore());

            CreateMap<Services.DTO.Event.EventDto, Web.ViewModels.Event.EditEventViewModel>(MemberList.None);

            CreateMap<Web.ViewModels.Event.CreateEventViewModel, Services.DTO.Event.CreateEventDto>(MemberList.None);

            CreateMap<Web.ViewModels.Event.EditEventViewModel, Services.DTO.Event.UpdateEventDto>(MemberList.None);


            CreateMap<Services.DTO.Reservation.ReservationDto, EventReservationItemViewModel>(MemberList.Destination);

            //Reservation
        }
    }
}
