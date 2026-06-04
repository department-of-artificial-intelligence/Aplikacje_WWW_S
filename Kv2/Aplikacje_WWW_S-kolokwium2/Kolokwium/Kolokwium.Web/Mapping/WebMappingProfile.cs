using AutoMapper;
using Kolokwium.Services.DTO;
using Kolokwium.Web.ViewModels.Person;

namespace App.Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            // Index List Mapping
            CreateMap<PersonDto, PersonViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Details Mapping
            CreateMap<PersonDto, DetailsPersonViewModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Create Mapping (Form -> DTO)
            CreateMap<CreatePersonViewModel, CreatePersonDto>();

            // Edit Mapping (Dwukierunkowe: DTO -> Form oraz Form -> DTO)
            CreateMap<PersonDto, EditPersonViewModel>();
            CreateMap<EditPersonViewModel, UpdatePersonDto>();
        }
    }
}