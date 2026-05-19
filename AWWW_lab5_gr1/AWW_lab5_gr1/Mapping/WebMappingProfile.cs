using AutoMapper;
using Services.DTO.Building;
using Services.DTO.Room;
using Web.ViewModels.Building;

namespace Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<BuildingDto, IndexBuildingViewModel>();  
            CreateMap<BuildingDto, EditBuildingViewModel>();   
            CreateMap<BuildingDto, DeleteBuildingViewModel>(); 
            CreateMap<BuildingDto, DetailsBuildingViewModel>(); 

            CreateMap<CreateBuildingViewModel, CreateBuildingDto>(); 
            CreateMap<EditBuildingViewModel, BuildingDto>();         

            CreateMap<RoomDto, BuildingRoomItemViewModel>(); 
        }
    }
}
