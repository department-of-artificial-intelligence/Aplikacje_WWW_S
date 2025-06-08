using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<Book, BookVm>()
        .ForMember(opt => opt.AuthorCredential, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.SurName))
        .ForMember(
            opt => opt.LibraryName,
            opt => opt.MapFrom(src => string.Join(", ", src.libraries.Select(l => l.Name)))
        );
        CreateMap<BookVm, Book>();
        

    }
}

