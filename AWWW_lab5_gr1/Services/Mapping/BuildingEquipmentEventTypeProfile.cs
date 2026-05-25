using AutoMapper;
using Model.DataModels;
using Services.DTO.Building;
using Services.DTO.Equipment;
using Services.DTO.EventType;

namespace Services.Mapping
{
    public class DictionaryProfile : Profile
    {
        public DictionaryProfile()
        {
            // Building
            CreateMap<Building, BuildingDto>();
            CreateMap<CreateBuildingDto, Building>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Rooms, o => o.Ignore());
            CreateMap<UpdateBuildingDto, Building>()
                .ForMember(d => d.Rooms, o => o.Ignore());

            // Eqiupment
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<CreateEquipmentDto, Equipment>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.RoomEquipments, o => o.Ignore());
            CreateMap<UpdateEquipmentDto, Equipment>()
                .ForMember(d => d.RoomEquipments, o => o.Ignore());

            // EventType
            CreateMap<EventType, EventTypeDto>();
            CreateMap<CreateEventTypeDto, EventType>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Events, o => o.Ignore());
            CreateMap<UpdateEventTypeDto, EventType>()
                .ForMember(d => d.Events, o => o.Ignore());
        }
    }
}