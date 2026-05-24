using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Web
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            // Mapowanie: DTO <-> ViewModel
            CreateMap<ScreeningDto, ScreeningVm>()
                .ReverseMap();
            CreateMap<CreateScreeningVm, ScreeningDto>();
        }
    }
}