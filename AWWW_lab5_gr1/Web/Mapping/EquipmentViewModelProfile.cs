using AutoMapper;
using Services.DTO.Equipment;
using Web.ViewModels.Equipment;

namespace Web.Mapping
{
    public class EquipmentViewModelProfile : Profile
    {
        public EquipmentViewModelProfile()
        {
            CreateMap<EquipmentDto, EquipmentListItemViewModel>();
            CreateMap<EquipmentDto, EquipmentDetailsViewModel>();
            CreateMap<EquipmentDto, EditEquipmentViewModel>();
            CreateMap<EquipmentDto, DeleteEquipmentViewModel>();

            CreateMap<CreateEquipmentViewModel, CreateEquipmentDto>();
            CreateMap<EditEquipmentViewModel, UpdateEquipmentDto>();
        }
    }
}