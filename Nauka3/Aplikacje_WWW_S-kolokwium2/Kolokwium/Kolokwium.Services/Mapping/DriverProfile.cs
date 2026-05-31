using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Model;
using Kolokwium.Services.DTO.Driver;
using AutoMapper;
using Kolokwium.Model.DataModels;

namespace Kolokwium.Services.Mapping
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            // 1. Do listy Index (Z bazy do DriverDto)
            CreateMap<Driver, DriverDto>(MemberList.None);

            // 2. Do ekranu szczegółów (Z bazy do DriverDetailsDto)
            CreateMap<Driver, DriverDetailsDto>(MemberList.None);

            // 3. Do formularza tworzenia (Z CreateDriverDto do bazy)
            CreateMap<CreateDriverDto, Driver>(MemberList.None);

            // 4. Do formularza edycji (Z UpdateDriverDto do bazy)
            CreateMap<UpdateDriverDto, Driver>(MemberList.None);
        }
    }
}
