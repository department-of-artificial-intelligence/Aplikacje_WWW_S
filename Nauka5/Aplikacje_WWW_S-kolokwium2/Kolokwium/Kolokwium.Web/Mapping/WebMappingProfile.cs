using AutoMapper;
using Kolokwium.Services.DTO.Book;
using Kolokwium.Web.ViewModels.Book;

namespace Kolokwium.Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            var config = MemberList.None;
           
            CreateMap<BookDto, IndexBookViewModel>(config);
            CreateMap<BookDetailsDto, DetailsBookViewModel>(config);
            CreateMap<CreateBookViewModel, CreateBookDto>(config);
            CreateMap<EditBookViewModel, UpdateBookDto>(config);
            CreateMap<BookDetailsDto, EditBookViewModel>(config)
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.ToList()))
                //.ForMember(dest => dest.AuthorIds, opt => opt.MapFrom(src => src.Authors.Select(a => a.Id).ToList()))Jakby bylo stringiem znowu
            // 2. ROZWIĄZANIE BŁĘDU: Nakazujemy zignorować te dwie właściwości, bo napełniasz je ręcznie w akcji kontrolera
                .ForMember(dest => dest.Authors, opt => opt.Ignore())
                .ForMember(dest => dest.Publishers, opt => opt.Ignore());

            /*CreateMap<BookDetailsDto, EditBookViewModel>(config) Jakby bylo 1 do 1
            // Nie ma AuthorIds, ignorujesz tylko puste koszyki na dropdowny
            .ForMember(dest => dest.Authors, opt => opt.Ignore())
            .ForMember(dest => dest.Publishers, opt => opt.Ignore());*/

        }
    }
}
