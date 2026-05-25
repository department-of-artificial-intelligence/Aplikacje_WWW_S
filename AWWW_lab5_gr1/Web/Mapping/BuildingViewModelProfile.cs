using AutoMapper;
using Services.DTO.Building;
using Web.ViewModels.Building;

namespace Web.Mapping
{
    public class BuildingViewModelProfile : Profile
    {
        public BuildingViewModelProfile()
        {
            CreateMap<BuildingDto, BuildingListItemViewModel>();
            CreateMap<BuildingDto, BuildingDetailsViewModel>()
                .ForMember(d => d.Rooms, o => o.Ignore());
            CreateMap<BuildingDto, EditBuildingViewModel>();
            CreateMap<BuildingDto, DeleteBuildingViewModel>();

            CreateMap<CreateBuildingViewModel, CreateBuildingDto>();
            CreateMap<EditBuildingViewModel, UpdateBuildingDto>();
        }
    }
}
