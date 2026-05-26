using AutoMapper;
using Model.DataModels;
using Services.DTO.Building;

namespace Services.Mapping
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingDto>();
            CreateMap<CreateBuildingDto, Building>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Rooms, o => o.Ignore());
            CreateMap<UpdateBuildingDto, Building>()
                .ForMember(d => d.Rooms, o => o.Ignore());
        }
    }
}
