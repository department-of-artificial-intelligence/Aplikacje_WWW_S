using AutoMapper;
using Kolokwium.Services.DTO.Car;
using Kolokwium.Services.DTO.Driver;
using Kolokwium.Services.DTO.Registration;
using Kolokwium.Web.ViewModels.Car;
using Kolokwium.Web.ViewModels.Driver;
using Kolokwium.Web.ViewModels.Registration;

namespace Kolokwium.Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile() 
        {
            // Zabezpieczenie przed wyjątkami o brakujące pola
            // (dzięki temu mapujemy tylko to, co ma takie same nazwy)
            var config = MemberList.None;

            // =======================================================
            // 1. MAPOWANIA DLA KIEROWCY (DRIVER)
            // =======================================================
            CreateMap<DriverDto, IndexDriverViewModel>(config);
            CreateMap<DriverDetailsDto, DetailsDriverViewModel>(config);
            CreateMap<CreateDriverViewModel, CreateDriverDto>(config);
            CreateMap<EditDriverViewModel, UpdateDriverDto>(config);

            // Dodaj to w konstruktorze swojego profilu mapowania:Gdy otwierasz stronę edycji,
            // system musi najpierw załadować z bazy aktualne dane (imię, nazwisko) i wsadzić je do inputów w HTML.
            // Ponieważ Twoja metoda GetByIdAsync w serwisie kierowcy zwraca DriverDetailsDto,
            // AutoMapper musi wiedzieć, jak przepisać te dane z powrotem do formularza EditDriverViewModel.
            CreateMap<DriverDetailsDto, EditDriverViewModel>(config);//(MemberList.None);

            // =======================================================
            // 2. MAPOWANIA DLA SAMOCHODU (CAR)
            // =======================================================
            CreateMap<CarDto, IndexCarViewModel>(config);
            CreateMap<CreateCarViewModel, CreateCarDto>(config);
            CreateMap<EditCarViewModel, UpdateCarDto>(config);

            // WYJĄTEK (Mapowanie ręczne dla spłaszczonych szczegółów):
            // Ponieważ w DetailsCarViewModel rozbiłeś imię i nazwisko na dwa pola,
            // musimy jawnie wskazać AutoMapperowi skąd ma wziąć te dane z CarDetailsDto.
            CreateMap<CarDetailsDto, DetailsCarViewModel>(config)
                .ForMember(dest => dest.DriverFirstName, opt => opt.MapFrom(src => src.DriverFirstName))
                .ForMember(dest => dest.DriverLastName, opt => opt.MapFrom(src => src.DriverLastName))
                .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.DocumentNumber))
                .ForMember(dest => dest.RegistrationIssueDate, opt => opt.MapFrom(src => src.IssueDate));


            CreateMap<CarDetailsDto, EditCarViewModel>(config);
            // =======================================================
            // 3. MAPOWANIA DLA REJESTRACJI (REGISTRATION)
            // =======================================================
            CreateMap<CreateRegistrationViewModel, RegistrationDto>(config);
        }
    }
}
