using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO;

namespace Kolokwium.Services
{
    public class ScreeningProfile : Profile
    {
        public ScreeningProfile()
        {
            // Mapowanie z Encji do DTO (dla odczytu - Index)
            CreateMap<Screening, ScreeningDto>()
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name));

            // Mapowanie z DTO do Encji (dla zapisu - Create)
            // Ignorujemy obiekt nawigacyjny 'Cinema', aby EF nie próbował go zapisywać jako nowy rekord!
            CreateMap<ScreeningDto, Screening>()
                .ForMember(dest => dest.Cinema, opt => opt.Ignore())
                .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(src => src.CinemaId));
        }
    }
}