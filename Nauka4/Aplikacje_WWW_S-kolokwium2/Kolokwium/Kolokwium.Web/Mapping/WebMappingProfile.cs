using AutoMapper;
using Kolokwium.Services.DTO.Author;
using Kolokwium.Services.DTO.Book;
using Kolokwium.Services.DTO.Publisher;
using Kolokwium.Web.ViewModels.Author;
using Kolokwium.Web.ViewModels.Book;
using Kolokwium.Web.ViewModels.Publisher;

namespace Kolokwium.Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            var config = MemberList.None;

            CreateMap<AuthorDto, IndexAuthorViewModel>(config);
            CreateMap<AuthorDetailsDto, DetailsAuthorViewModel>(config);
            CreateMap<CreateAuthorViewModel, CreateAuthorDto>(config);
            CreateMap<EditAuthorViewModel, UpdateAuthorDto>(config);
            CreateMap<AuthorDetailsDto, EditAuthorViewModel>(config);

            
            CreateMap<BookDto, IndexBookViewModel>(config);
            CreateMap<BookDetailsDto, DetailsBookViewModel>(config);
            CreateMap<CreateBookViewModel, CreateBookDto>(config);
            CreateMap<EditBookViewModel, UpdateBookDto>(config);
            CreateMap<BookDetailsDto, EditBookViewModel>(config)
                // 1. Wyciągamy identyfikatory aktualnych autorów (to już masz, jeśli dopisałeś wcześniej)
                .ForMember(dest => dest.AuthorIds, opt => opt.MapFrom(src => src.Authors.Select(a => a.Id).ToList()))
            // 2. ROZWIĄZANIE BŁĘDU: Nakazujemy zignorować te dwie właściwości, bo napełniasz je ręcznie w akcji kontrolera
                .ForMember(dest => dest.Authors, opt => opt.Ignore())
                .ForMember(dest => dest.Publishers, opt => opt.Ignore());

            
            CreateMap<PublisherDto, IndexPublisherViewModel>(config);
            CreateMap<CreatePublisherViewModel, PublisherDto>(config);

        }
    }
}
