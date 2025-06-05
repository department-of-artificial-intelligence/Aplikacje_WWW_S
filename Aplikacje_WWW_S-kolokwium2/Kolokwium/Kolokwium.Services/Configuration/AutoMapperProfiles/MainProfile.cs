using AutoMapper;
using Kolokwium.ViewModel.VM;
namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
         CreateMap<Book, BookVm>()
            .ForMember(dest => dest.AutorNameSurname,
                opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));

    }
}

// This AutoMapper profile maps the Book entity to the BookVm view model.
// It combines the Author's Name and Surname into a single property AutorNameSurname in the view model.
// The CreateMap method defines the mapping configuration, allowing for easy transformation of data between the entity and the view model.
// The ForMember method specifies how to map the AutorNameSurname property by concatenating the Author's Name and Surname.

// DOALEM using Kolokwium.ViewModel.VM;