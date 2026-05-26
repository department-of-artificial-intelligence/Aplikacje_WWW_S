namespace Web.Mapping
{
    public class RoomEquipmentViewModelProfile : Profile
    {
        public RoomEquipmentViewModelProfile()
        {
            CreateMap<EquipmentDto, AddRoomEquipmentViewModel>()
            .ForMember(d => d.RoomId, o => o.Ignore())
            .ForMember(d => d.EquipmentId, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.EquipmentName, o => o.MapFrom(s => s.Name))
            .ForMember(d => d.IsSelected, o => o.Ignore())
            .ForMember(d => d.Quantity, o => o.Ignore());

            CreateMap<AddRoomEquipmentRowViewModel, CreateRoomEquipmentDto>()
            .ForMember(d => d.RoomId, o => o.MapFrom(s => s.RoomId))
            .ForMember(d => d.EquipmentId, o => o.MapFrom(s => s.EquipmentId))
            .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity));
        }
    }
}