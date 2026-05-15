using Model;
using Services.DTO.Building;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingDto>().ReverseMap();

            CreateMap<CreateBuildingDto, Building>()
                .ForMember(d => d.Id, o => o.Ignore())    
                .ForMember(d => d.Rooms, o => o.Ignore()); 

            CreateMap<UpdateBuildingDto, Building>()
                .ForMember(d => d.Rooms, o => o.Ignore()); 
        }
    }
}
