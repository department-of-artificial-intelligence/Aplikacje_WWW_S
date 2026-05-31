using AutoMapper;
using Kolokwium.Model;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Car;
using Kolokwium.Services.DTO.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Mapping
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>(MemberList.None); // Pod GetAll i GetByDriverId

            CreateMap<Car, CarDetailsDto>(MemberList.None); // Pod GetById (Szczegóły)

            CreateMap<CreateCarDto, Car>(MemberList.None);// Pod Create

            CreateMap<UpdateCarDto, Car>(MemberList.None); //Pod Update
        }
    }
}
