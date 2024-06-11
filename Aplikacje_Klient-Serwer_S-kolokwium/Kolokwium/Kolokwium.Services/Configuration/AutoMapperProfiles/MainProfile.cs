using AutoMapper;
using Kolokwium.Model.DataModels;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<User, UserVm>();

        CreateMap<UserVm, User>();

    }
}

