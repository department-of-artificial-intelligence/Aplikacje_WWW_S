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

            //CreateMap<Car, CarDetailsDto>(MemberList.None); // Pod GetById (Szczegóły)

            CreateMap<Car, CarDetailsDto>(MemberList.None)//Trzeba recznie zmapowac zeby wyswietlalo a nie tak jak wczesniej
                // 1. Mapowanie danych kierowcy z relacji (1:N)
                .ForMember(dest => dest.DriverFirstName, opt => opt.MapFrom(src => src.Driver.FirstName))
                .ForMember(dest => dest.DriverLastName, opt => opt.MapFrom(src => src.Driver.LastName))
                // 2. Mapowanie danych dowodu rejestracyjnego z relacji (1:1)
                // Upewnij się, że "Registration" to dokładna nazwa właściwości w Twojej encji Car!
                .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.Registration.DocumentNumber))
                .ForMember(dest => dest.IssueDate, opt => opt.MapFrom(src => src.Registration.IssueDate));

            CreateMap<CreateCarDto, Car>(MemberList.None);// Pod Create

            CreateMap<UpdateCarDto, Car>(MemberList.None); //Pod Update
        }
    }
}
