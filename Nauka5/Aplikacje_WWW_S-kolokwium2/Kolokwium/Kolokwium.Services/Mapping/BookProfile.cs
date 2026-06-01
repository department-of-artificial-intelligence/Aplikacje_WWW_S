using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Book;

namespace Kolokwium.Services.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>(MemberList.None)
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name));

            CreateMap<Book, BookDetailsDto>(MemberList.None)
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name));

            // 3. Pod tworzenie (Ignore dla kolekcji Authors, bo przypiszemy ich ręcznie w serwisie przez ID)
            CreateMap<CreateBookDto, Book>(MemberList.None);
            //.ForMember(dest => dest.Authors, opt => opt.Ignore());

            // 4. Pod edycję
            CreateMap<UpdateBookDto, Book>(MemberList.None);
            //.ForMember(dest => dest.Authors, opt => opt.Ignore());

            CreateMap<Book, BookDetailsDto>()
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.ToList()));




            //Gdyby bylo stringiem ale wczesniej tak zrobilem dla typu author i tez zadzialalo
            /*CreateMap<Book, BookDetailsDto>()
            .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
            // JAWNE MAPOWANIE: Mówimy, że chcemy tylko listę imion i nazwisk (stringów)
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(a => a.FullName).ToList()));*/

            /*CreateMap<BookDetailsDto, EditBookViewModel>(config) Jakby bylo 1 do 1
           // Nie ma AuthorIds, ignorujesz tylko puste koszyki na dropdowny
           .ForMember(dest => dest.Authors, opt => opt.Ignore())
           .ForMember(dest => dest.Publishers, opt => opt.Ignore());*/


        }
    }
}
