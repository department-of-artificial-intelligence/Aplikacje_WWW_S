using AutoMapper;
using Model.DataModels;
using Services.DTO.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<Equipment, EquipmentDto>();

            CreateMap<CreateEquipmentDto, Equipment>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.RoomEquipments, o => o.Ignore())
                .ForMember(d => d.IsMobile, o => o.Ignore()); 

            CreateMap<UpdateEquipmentDto, Equipment>()
                .ForMember(d => d.RoomEquipments, o => o.Ignore())
                .ForMember(d => d.IsMobile, o => o.Ignore()); 
        }
    }
}
