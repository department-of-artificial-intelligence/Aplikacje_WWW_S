using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
        //AutoMapper maps
        CreateMap<Student, StudentVm>()
            .ForMember(dest => dest.StudentName, x => x.MapFrom(src => $"{src.FirstName} {src.LastName}")); 

        CreateMap<AddOrUpdateStudentVm, Student>(); 
        CreateMap<StudentVm, AddOrUpdateStudentVm>(); 
        
    }
}

