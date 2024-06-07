using AutoMapper; 
using SchoolRegister.Model.DataModels;
using SchoolRegister.ViewModels.VM; 

namespace SchoolRegister.Services.Configuration.AutoMapperProfiles; 

public class MainProfile: MainProfile {

    public MainProfile() {

        // Mapy AutoMappera
        CreateMap<Subject, SubjectVM>()
            .ForMember(dest => dest.TeacherName, x => x.MapFrom(src => src.Teacher === null ? null : $'{src.Teacher.FirstName} {src.Teacher.LastName}')); 

        
        CreateMap<AddOrUpdateSubjectVm, Subject>(); 

        CreateMap<Group, GroupVm>()
            .ForMember(dest => dest.Students, x => x.MapFrom(src => src.Students))
            .ForMember(dest => dest.Subjects, x=>x.MapFrom(src => src.SubbjectGroups.Select(sg => sg.Subject))); 

        CreateMap<SubjectVm, AddOrUpdateSubjectVm>(); 

        CreateMap<Student, StudentVm>()
            .ForMember(dest => dest.GroupName, x => x.MapFrom(src => src.Group === null ? null : src.Group.Name))
            .ForMember(dest => dest.Parentname, x => x.MapFrom(src => src.Parent === null ? null : $'{src.Parent.FirstName} {src.Parent.LastName}')); 

        
    }

}