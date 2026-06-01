using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Book;
using Kolokwium.Services.DTO.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Mapping
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>(MemberList.None).ReverseMap();



            // To by bylo jakbym tam zrobil stringa i sam tytul chcialbym wyciagnac POPRAWIONO: Wyciągamy same tytuły za pomocą .Select(b => b.Title)
            //.ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books.Select(b => b.Title)));
        }
    }
}
