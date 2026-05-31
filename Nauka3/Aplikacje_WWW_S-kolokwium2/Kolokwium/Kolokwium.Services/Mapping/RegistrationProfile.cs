using AutoMapper;
using Kolokwium.Model;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Car;
using Kolokwium.Services.DTO.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Mapping
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            // Służy zarówno do odczytu w GetByCarId, jak i zapisu w CreateAsync
            CreateMap<Registration, RegistrationDto>(MemberList.None).ReverseMap(); 

        }
    }
}
