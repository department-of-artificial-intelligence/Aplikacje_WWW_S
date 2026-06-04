using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO;

namespace Kolokwium.Services.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            // Standardowe pobieranie danych (z encji na ogólny PersonDto)
            CreateMap<Person, PersonDto>();

            // Mapowanie dla tworzenia (z CreateDto na Encję)
            CreateMap<CreatePersonDto, Person>();

            // Mapowanie dla aktualizacji (dwukierunkowe, z UpdateDto na Encję i odwrotnie)
            CreateMap<UpdatePersonDto, Person>().ReverseMap();
        }
    }
}