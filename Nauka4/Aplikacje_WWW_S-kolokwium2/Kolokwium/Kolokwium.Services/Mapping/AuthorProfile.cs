using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Author;
using Kolokwium.Services.DTO.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>(MemberList.None);

            CreateMap<Author, AuthorDetailsDto>(MemberList.None);

            CreateMap<CreateAuthorDto, Author>(MemberList.None);

            CreateMap<UpdateAuthorDto, Author>(MemberList.None);


        }
    }
}
