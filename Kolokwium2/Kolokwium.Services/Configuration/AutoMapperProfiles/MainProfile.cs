using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
       CreateMap<Ksiazka, KsiazkiVm>()
            .ForMember(dest => dest.ImieNazwiskoAutora, opt => opt.MapFrom(src => src.Autor.Imie + " " + src.Autor.Nazwisko))
            .ForMember(dest => dest.WydawnictwoNazwa, opt => opt.MapFrom(src => src.Wydawnictwo.Nazwa));
        CreateMap<AddKsiazkaVm, Ksiazka>()
            .ForMember(dest => dest.WydawnictwoId, opt => opt.MapFrom(src => src.WydawnictwoId));
        CreateMap<Wydawnictwo, WydawnictwoVm>();
    }
}

